create procedure [dbo].[up_InsertDeviceErrorInfo]
	@DevIp		nvarchar(50),		--�豸IP
	@ChannelNo	varchar(10),		--ͨ�����
	@AddTime	varchar(30),		--�쳣ʱ��
	@ErrorCode	varchar(10),		--�쳣��
	@CaseNo		nvarchar(50),		--����
	@TrialNum	int					--ͥ��
	
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