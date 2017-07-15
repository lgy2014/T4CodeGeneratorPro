create procedure [dbo].[up_CountSumDurationByCourtType]
	@courtCode varchar(50),	--法院代码
	@beginTime datetime,	--开始时间
	@endTime datetime		--截止时间
as
begin
	declare @tmp_table table
	(
		CourtId int,
		CourtName varchar(50),
		SumDuration float
	)
	
	insert into @tmp_table(CourtId,CourtName)
	select CourtId,CourtName from t_CourtInfo
	where CourtCode=@courtCode
	order by CourtId asc
	
	declare @CourtId int
	declare tmp_cursor cursor
	for select CourtId from @tmp_table
	open tmp_cursor
	fetch next from tmp_cursor into @CourtId
	while @@FETCH_STATUS=0
	begin
		declare @SumDuration float
		
		select @SumDuration=ISNULL(SUM(datediff(MINUTE,BeginRecoderTime,EndRecoderTime)),0)
		from (
			select a.BeginRecoderTime,a.EndRecoderTime
			from t_CaseInfo as c
			left outer join t_AudioInfo as a on c.CaseCode=a.CaseId
			where c.CourtCode=@courtCode and a.BeginRecoderTime>=@beginTime and a.EndRecoderTime<=@endTime
				and c.CourtId=@CourtId
			group by a.BeginRecoderTime,a.EndRecoderTime
		) as f
		
		select @SumDuration=@SumDuration/60.0
		
		update @tmp_table set SumDuration=@SumDuration where CourtId=@CourtId
		fetch next from tmp_cursor into @CourtId
	end
	close tmp_cursor
	deallocate tmp_cursor
	
	select * from @tmp_table
	
end