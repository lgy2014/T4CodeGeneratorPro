CREATE procedure [dbo].[up_CountError]
	@courtCode varchar(50),	--法院代码
	@beginTime datetime,	--开始时间
	@endTime datetime		--截止时间
as
begin
--表一：根据异常类型统计
select Dict,count(*) as num
	from t_DeviceRunErrorMsg as d
	left outer join t_Channel as c on d.ChannelId=c.ChannelId
	left outer join t_AudioComputer as a on c.ComputerId=a.ComputerId
	left outer join t_Dict as dt on dt.DictCode=d.ErrorCode
	where a.CourtCode=@courtCode and d.AddTime>=@beginTime and d.AddTime<=@endTime and dt.DataCode='ECtype'
	group by Dict
	
	--表二：根据异常类型，主机存放地址统计
	select Dict,a.ComputerPosition,count(*) as num
	from t_DeviceRunErrorMsg as d
	left outer join t_Channel as c on d.ChannelId=c.ChannelId
	left outer join t_AudioComputer as a on c.ComputerId=a.ComputerId
	left outer join t_Dict as dt on dt.DictCode=d.ErrorCode
    where a.CourtCode=@courtCode and d.AddTime>=@beginTime and d.AddTime<=@endTime and dt.DataCode='ECtype'
	group by Dict,a.ComputerPosition order by Dict

end