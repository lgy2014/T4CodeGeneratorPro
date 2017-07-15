CREATE procedure [dbo].[up_GetSeatAudio]
	@CaseCode varchar(50)
as
begin
   declare @groupId int
   select @groupId=isnull(groupId,0) from t_AudioInfo where CaseId=@CaseCode
	 if(@groupId>0)
	 begin
		select groupId from t_AudioInfo where CaseId=@CaseCode group by groupId order by groupId
		
		select AudioId,CaseId,SeatName,ChannelId,AudioUri,Duration,BeginRecoderTime=CONVERT(varchar(20),BeginRecoderTime,120),groupId  from t_AudioInfo where CaseId=@CaseCode
		order by ChannelId 
		end 
		else
		begin
			select groupId,BeginRecoderTime=CONVERT(varchar(20),BeginRecoderTime,120) from t_AudioInfo where CaseId=@CaseCode
			group by groupId,CONVERT(varchar(20),BeginRecoderTime,120) order by groupId,BeginRecoderTime
		
			select AudioId,CaseId,SeatName,ChannelId,AudioUri,Duration,BeginRecoderTime=CONVERT(varchar(20),BeginRecoderTime,120),groupId  from t_AudioInfo where CaseId=@CaseCode
			order by ChannelId 
		end
end