create procedure [dbo].[up_CountCourtCaseType]
	@beginTime datetime,	--开始时间
	@endTime datetime		--截止时间
as
begin

	select distinct CaseType from t_CaseInfo
	select CourtCode,CourtName from t_Court
	exec up_CountAvgDurationByCaseType '',@beginTime,@endTime
	
end