create procedure [dbo].[up_GetNoticeUserList]
	@deviceIp varchar(15) ='',
	@channelNo int = 0
as
begin
	
	declare @CourtId int
	declare @CourtName nvarchar(50)
	declare @SeatName nvarchar(50)
	
	declare @State nvarchar(50)
	
	
	select @CourtId=ci.CourtId,@CourtName=ci.CourtName,@SeatName=SeatName from t_Channel as c
	left outer join t_AudioComputer as a on c.ComputerId=a.ComputerId
	left outer join t_Seat as s on s.ChannelId=c.ChannelId
	left outer join t_CourtInfo as ci on ci.CourtId=s.CourtId
	where a.ComputerIp=@deviceIp and c.ChannelNo='CH'+convert(varchar,(@channelNo+1))
	
	if exists(select 1 from t_CaseInfo where CourtId=@CourtId and Flag=14)
		select @State='ͥ����'
	else
		select @State='δ��ͥ'
	
	select top 1 UserId=UserName,UserName=Name,Phone,
		Content=('������' +@CourtName+'��ǰ״̬'+'��ͥ���С�'
		+'����˵����ʰ���������쳣��������λ�á�'+@SeatName+'����ʱ��'+CONVERT(varchar(8),GETDATE(),8))
	from t_User as u
	left outer join t_user_role as ur on u.UserCode=ur.UserCode
	left outer join t_AuthorityManager as am on am.ObjectCode=ur.RoleCode and am.ObjectType=2
	left outer join t_Menu as m on m.MenuId=am.MenuId
	where m.MenuName='��ͥ���' and isnull(Phone,'')>''
	order by u.UserCode asc
	
		
end