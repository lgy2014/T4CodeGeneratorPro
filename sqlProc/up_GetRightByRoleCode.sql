CREATE procedure [dbo].[up_GetRightByRoleCode]
	@RoleCode varchar(50)
as
begin
		select m.MenuId,m.ParentId,m.MenuName,m.Href,m.OrderAse,RightQuery,RightEdit
		from t_AuthorityManager a
		left outer join t_menu as m on a.MenuId=m.MenuId
		where a.ObjectType=2 and ObjectCode =@RoleCode
			order by m.OrderAse asc
		
end