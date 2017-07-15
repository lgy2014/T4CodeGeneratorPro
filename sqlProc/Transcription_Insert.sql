CREATE Proc [dbo].[Transcription_Insert]
(
	@UserID Int,						--操作人员ID
	@CaseCode varchar(50),						--案件编号
	@TranscriptionContent varchar(Max),	--誊录内容
	@Transcriptor Int,					--誊录人员
	@TranscriptionCheck Int,			--确认人员
	@Type Int,							--誊录类型 1:保存 2:提交 3:确认 -1:不保存状态
	@ErrMsg NvarChar(200) Output		--返回错误信息
)
AS
Begin Tran Transcription_Insert_Tran
	Declare	@ErrNum Int = 0			--错误代码
	Declare @oStatus Int			--保存已有誊录状态
	Declare @oClerkId Int			--保存当前案件书记员ID
	Declare @Status NvarChar(50)	--保存新誊录状态
	
	If @Type = 1
	Begin
		If @Transcriptor < 1
		Begin
			Set @ErrNum = 201
			Set @ErrMsg = '誊录人员信息不存在，请重新登陆'
			Goto theEnd
		End
	End
	If @Type = 3
	Begin
		
		If @TranscriptionCheck < 1
		Begin
			Set @ErrNum = 201
			Set @ErrMsg = '确认人员信息不存在，请重新登陆'
			Goto theEnd
		End
		
	End
	If Exists(Select Top 1 1 From Transcription Where CaseCode = @CaseCode)		--修改操作
	Begin
		Select @oStatus = Status From Transcription Where CaseCode = @CaseCode
		If @Type = 1		--保存
		Begin
			If @oStatus = '08'--已确认
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '誊录已确认，不能进行保存操作'
				Goto theEnd
			End
			
			Set @Status = '05'
		End
		Else If @Type = 2	--提交
		Begin
			If @oStatus = '08'--已确认
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '誊录已确认，不能进行提交操作'
				Goto theEnd
			End
			
			select @TranscriptionCheck=UserCode from t_CaseInfo 
			left outer join t_User on UserName=JudgeId 
			Where CaseCode = @CaseCode
			Update Transcription Set TranscriptionCheck=@TranscriptionCheck Where CaseCode = @CaseCode
			Set @Status = '06'
		End
		Else If @Type = 3	--确认
		Begin
			Select @oClerkId = ClerkId From t_CaseInfo Where CaseCode = @CaseCode
			If @UserID <> @oClerkId
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '您不是该案件书记员，不能进行此操作'
				Goto theEnd
			End
			If @oStatus = '04'--未誊录
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '还未誊录信息，不能进行确认操作'
				Goto theEnd
			End
			If @oStatus = '05'--誊录中
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '信息在誊录中，不能进行确认操作'
				Goto theEnd
			End
			If @oStatus = '08'--已确认
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '誊录已确认，不需要再次进行确认'
				Goto theEnd
			End
			
			Set @Status = '08'
		End
		Update Transcription Set TranscriptionContent = @TranscriptionContent,Transcriptor=@Transcriptor
		,Status = @Status Where CaseCode = @CaseCode
		
		if(@Type<>-1)
			update t_CaseAudio set Flag_Transcribe=@Status Where CaseId = @CaseCode
		
		If @@ERROR <> 0
		Begin
			Set @ErrNum = 201
			Set @ErrMsg = '添加誊录信息发生错误，请重新操作'
			Goto theEnd
		End
	End
	Else																			--添加操作
	Begin
		Insert Into Transcription(CaseCode,TranscriptionContent,Transcriptor,Status,SubmitTime) 
		 Values(@CaseCode,@TranscriptionContent,@Transcriptor,'05',GETDATE())
		If @@ERROR <> 0
		Begin
			Set @ErrNum = 201
			Set @ErrMsg = '添加誊录信息发生错误，请重新操作'
			Goto theEnd
		End
	End


theEnd:
	If @ErrNum = 0
	Begin
		Commit Tran
	End
	Else
	Begin
		RollBack Tran
	End