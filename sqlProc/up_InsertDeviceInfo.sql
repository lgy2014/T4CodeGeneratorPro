create procedure [dbo].[up_InsertDeviceInfo]
	@CourtCode varchar(50),
	@ComputerIp varchar(50),
	@Name nvarchar(50),
	@ChannelNum int
as
begin
    DECLARE @Id int
    SELECT @Id=0
    
	IF NOT EXISTS(SELECT 1 FROM t_AudioComputer WHERE ComputerIp=@ComputerIp)
	BEGIN
		INSERT INTO [dbo].[t_AudioComputer] ([ComputerIp],[ComputerPosition],[ChannelCount],[CourtCode])
		VALUES(@ComputerIp,@Name,@ChannelNum,@CourtCode)
		
		SELECT @Id=@@IDENTITY
		
		DECLARE @CNum int
		SELECT @CNum=1
		WHILE(@ChannelNum>=@CNum)
		BEGIN
			INSERT INTO t_Channel(ComputerId,ChannelNo,Flag)
			VALUES(@Id,'CH'+convert(varchar,@CNum),1)
			SELECT @CNum=@CNum+1
		END		
	END
	ELSE
	BEGIN
		DECLARE @CNumTmp INT
		SELECT TOP 1 @CNumTmp=ChannelCount FROM t_AudioComputer WHERE ComputerIp=@ComputerIp
		IF(@ChannelNum>@CNumTmp)
		BEGIN
			UPDATE t_AudioComputer SET ChannelCount=@ChannelNum WHERE ComputerIp=@ComputerIp
			SELECT TOP 1 @Id=ComputerId FROM t_AudioComputer WHERE ComputerIp=@ComputerIp
			WHILE(@ChannelNum>@CNumTmp)
			BEGIN
				INSERT INTO t_Channel(ComputerId,ChannelNo,Flag)
				VALUES(@Id,'CH'+convert(varchar,@CNumTmp+1),1)
				SELECT @CNumTmp=@CNumTmp+1
			END
		END
	END	
		
END