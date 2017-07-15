CREATE procedure [dbo].[up_GetRightByUserCode]
	@UserName varchar(50)
as
begin
	if(@UserName='admin')
		select MenuId,ParentId,MenuName,Href,OrderAse,RightQuery=1,RightEdit=1
		from t_menu  where MenuId!='Report02'
		order by OrderAse asc
	else
	begin
		WITH MenuEntity(MenuId,ParentId,MenuName,Href,OrderAse,RightQuery,RightEdit)
		AS( 
			select m.MenuId,m.ParentId,m.MenuName,m.Href,m.OrderAse,RightQuery,RightEdit
			from t_menu m
			INNER JOIN t_AuthorityManager as a on a.MenuId=m.MenuId
			where (a.ObjectType=1 and ObjectCode=@UserName) 
				or (a.ObjectType=2 and ObjectCode in(
					select ur.RoleCode from t_user_role as ur 
					left outer join t_User as u on u.UserCode=ur.UserCode
					where u.UserName=@UserName))
			

			UNION ALL
			SELECT m.MenuId,m.ParentId,m.MenuName,m.Href,m.OrderAse,A.RightQuery,A.RightEdit
			from t_menu m
			INNER JOIN t_AuthorityManager as A on a.MenuId=m.MenuId
			INNER JOIN MenuEntity AS B ON B.ParentId=A.MenuId
		)

		SELECT distinct MenuId,ParentId,MenuName,Href,OrderAse,RightQuery=(
			SELECT TOP 1 RightQuery FROM MenuEntity AS B WHERE B.MenuId=A.MenuId ORDER BY RightQuery DESC
		),
		RightEdit =(
			SELECT TOP 1 RightEdit FROM MenuEntity AS B WHERE B.MenuId=A.MenuId ORDER BY RightEdit DESC
		)
		FROM MenuEntity AS A where MenuId!='Report02'
		
	end
end