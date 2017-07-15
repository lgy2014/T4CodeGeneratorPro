create procedure [dbo].[up_CountAvgDurationByCaseType]
	@courtCode varchar(50),	--法院代码
	@beginTime datetime,	--开始时间
	@endTime datetime		--截止时间
as
begin
	declare @tmp_table table
	(
		CourtCode varchar(50),
		CaseType varchar(50),
		AvgDuration float
	)
	
	insert into @tmp_table(CourtCode,CaseType)
	select distinct CourtCode,CaseType from t_CaseInfo
	where (CourtCode=@courtCode or @courtCode='')
	
	declare @CaseType varchar(50)
	declare @CourtCode2 varchar(50)
	
	declare tmp_cursor cursor
	for select CourtCode,CaseType from @tmp_table
	open tmp_cursor
	fetch next from tmp_cursor into @CourtCode2,@CaseType
	while @@FETCH_STATUS=0
	begin
		declare @AvgDuration float
		declare @count int
		
		select @count=COUNT(1)
		from t_CaseInfo as c
		left outer join t_AudioInfo as a on c.CaseCode=a.CaseId
		where c.CourtCode=@CourtCode2 and a.BeginRecoderTime>=@beginTime and a.EndRecoderTime<=@endTime
			and c.CaseType=@CaseType
		
		if(@count=0)
		begin
			select @AvgDuration=0
		end
		else
		begin
			select @AvgDuration=ISNULL(SUM(datediff(MINUTE,a.BeginRecoderTime,a.EndRecoderTime)),0) 
			from t_CaseInfo as c
			left outer join t_AudioInfo as a on c.CaseCode=a.CaseId
			where c.CourtCode=@CourtCode2 and a.BeginRecoderTime>=@beginTime and a.EndRecoderTime<=@endTime
				and c.CaseType=@CaseType
			select @AvgDuration=@AvgDuration/@count
			
		end
		
		select @AvgDuration=@AvgDuration/60.0
		
		update @tmp_table set AvgDuration=@AvgDuration where CaseType=@CaseType and CourtCode=@CourtCode2
		fetch next from tmp_cursor into @CourtCode2,@CaseType
	end
	close tmp_cursor
	deallocate tmp_cursor
	
	select * from @tmp_table
	
end