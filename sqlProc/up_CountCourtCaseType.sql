create procedure [dbo].[up_CountCourtCaseType]
	@beginTime datetime,	--��ʼʱ��
	@endTime datetime		--��ֹʱ��
as
begin

	select distinct CaseType from t_CaseInfo
	select CourtCode,CourtName from t_Court
	exec up_CountAvgDurationByCaseType '',@beginTime,@endTime
	
end