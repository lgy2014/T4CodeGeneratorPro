create procedure [dbo].[up_InsertDeviceErrorInfo]
	@DevIp		nvarchar(50),		--设备IP
	@ChannelNo	varchar(10),		--通道编号
	@AddTime	varchar(30),		--异常时间
	@ErrorCode	varchar(10),		--异常码
	@CaseNo		nvarchar(50),		--案号
	@TrialNum	int					--庭次
	
as
begin
	DECLARE @CaseCode varchar(50)
    SELECT @CaseCode=CaseCode from t_CaseInfo where CaseNo=@CaseNo and TrialCount=@TrialNum
    
    DECLARE @ChannelId int
    SELECT @ChannelId=0
    
    SELECT TOP 1 @ChannelId=C.ChannelId FROM t_Channel AS C
    LEFT OUTER JOIN t_AudioComputer AS A ON A.ComputerId=C.ComputerId
    WHERE A.ComputerIp=@DevIp AND C.ChannelNo='CH'+@ChannelNo
    
	INSERT INTO t_DeviceRunErrorMsg (ChannelId,AddTime,ErrorCode,CaseCode)
	VALUES(@ChannelId,@AddTime,@ErrorCode,@CaseCode)
END