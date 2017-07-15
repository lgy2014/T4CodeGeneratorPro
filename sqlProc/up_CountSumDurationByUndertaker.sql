CREATE procedure [dbo].[up_CountSumDurationByUndertaker]
	@courtCode varchar(50),	--法院代码
	@beginTime datetime,	--开始时间
	@endTime datetime,		--截止时间
	@depId varchar(50)		--部门
as
begin

	declare @tmp_table table
	(
		UserId varchar(50),
		UserName varchar(50),
		SumDuration float
	)
	
	insert into @tmp_table(UserId,UserName)
	select distinct UndertakerId,u.Name from t_CaseInfo
	left outer join t_user as u on u.UserName=UndertakerId
	where CourtCode=@courtCode and u.DepartCode=@depId--增加部门过滤
	order by UndertakerId asc
	
	declare @UserId varchar(50)
	declare tmp_cursor cursor
	for select UserId from @tmp_table
	open tmp_cursor
	fetch next from tmp_cursor into @UserId
	while @@FETCH_STATUS=0
	begin
		declare @SumDuration float
		
		select @SumDuration=ISNULL(SUM(datediff(MINUTE,BeginRecoderTime,EndRecoderTime)),0)
		from 
		(
			select a.BeginRecoderTime,a.EndRecoderTime
			from t_CaseInfo as c
			left outer join t_AudioInfo as a on c.CaseCode=a.CaseId
			where c.CourtCode=@courtCode and a.BeginRecoderTime>=@beginTime and a.EndRecoderTime<=@endTime
				and c.UndertakerId=@UserId
			group by a.BeginRecoderTime,a.EndRecoderTime
		) as f
		
		select @SumDuration=@SumDuration/60.0
		
		update @tmp_table set SumDuration=@SumDuration where UserId=@UserId
		
		fetch next from tmp_cursor into @UserId
	end
	close tmp_cursor
	deallocate tmp_cursor
	
	select * from @tmp_table
	
end