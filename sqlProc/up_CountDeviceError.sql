CREATE procedure [dbo].[up_CountDeviceError]
	@courtCode varchar(50),	--��Ժ����
	@beginTime datetime,	--��ʼʱ��
	@endTime datetime		--��ֹʱ��
as
begin

	declare @tmp_table table
	(
		DeviceIp   varchar(50),
		DeviceName nvarchar(50),
		ChannelNo   varchar(10),
		Num int
	)
	
	select ChannelNum=ISNULL(MAX(ChannelCount),0) from t_AudioComputer where CourtCode=@courtCode
	--ֻ��ʾ���쳣����������
	--select DeviceIp=ComputerIp,DeviceName=ComputerPosition from t_AudioComputer where CourtCode=@courtCode
	select DeviceIp=a.ComputerIp,DeviceName=a.ComputerPosition
	from t_DeviceRunErrorMsg as d
	left outer join t_Channel as c on d.ChannelId=c.ChannelId
	left outer join t_AudioComputer as a on c.ComputerId=a.ComputerId
	where a.CourtCode=@courtCode and d.AddTime>=@beginTime and d.AddTime<=@endTime
	group by a.ComputerIp,a.ComputerPosition

	
	insert into @tmp_table(DeviceIp,DeviceName,ChannelNo,Num)
	select Ip=a.ComputerIp,DeviceName=a.ComputerPosition,c.ChannelNo,Num=COUNT(d.ID) 
	from t_DeviceRunErrorMsg as d
	left outer join t_Channel as c on d.ChannelId=c.ChannelId
	left outer join t_AudioComputer as a on c.ComputerId=a.ComputerId
	where a.CourtCode=@courtCode and d.AddTime>=@beginTime and d.AddTime<=@endTime
	group by a.ComputerIp,a.ComputerPosition,c.ChannelNo
		
	select * from @tmp_table
	
end