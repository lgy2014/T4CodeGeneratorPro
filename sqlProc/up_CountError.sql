CREATE procedure [dbo].[up_CountError]
	@courtCode varchar(50),	--��Ժ����
	@beginTime datetime,	--��ʼʱ��
	@endTime datetime		--��ֹʱ��
as
begin
--��һ�������쳣����ͳ��
select Dict,count(*) as num
	from t_DeviceRunErrorMsg as d
	left outer join t_Channel as c on d.ChannelId=c.ChannelId
	left outer join t_AudioComputer as a on c.ComputerId=a.ComputerId
	left outer join t_Dict as dt on dt.DictCode=d.ErrorCode
	where a.CourtCode=@courtCode and d.AddTime>=@beginTime and d.AddTime<=@endTime and dt.DataCode='ECtype'
	group by Dict
	
	--����������쳣���ͣ�������ŵ�ַͳ��
	select Dict,a.ComputerPosition,count(*) as num
	from t_DeviceRunErrorMsg as d
	left outer join t_Channel as c on d.ChannelId=c.ChannelId
	left outer join t_AudioComputer as a on c.ComputerId=a.ComputerId
	left outer join t_Dict as dt on dt.DictCode=d.ErrorCode
    where a.CourtCode=@courtCode and d.AddTime>=@beginTime and d.AddTime<=@endTime and dt.DataCode='ECtype'
	group by Dict,a.ComputerPosition order by Dict

end