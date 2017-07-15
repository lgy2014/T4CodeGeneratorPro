CREATE Proc [dbo].[Transcription_Insert]
(
	@UserID Int,						--������ԱID
	@CaseCode varchar(50),						--�������
	@TranscriptionContent varchar(Max),	--��¼����
	@Transcriptor Int,					--��¼��Ա
	@TranscriptionCheck Int,			--ȷ����Ա
	@Type Int,							--��¼���� 1:���� 2:�ύ 3:ȷ�� -1:������״̬
	@ErrMsg NvarChar(200) Output		--���ش�����Ϣ
)
AS
Begin Tran Transcription_Insert_Tran
	Declare	@ErrNum Int = 0			--�������
	Declare @oStatus Int			--����������¼״̬
	Declare @oClerkId Int			--���浱ǰ�������ԱID
	Declare @Status NvarChar(50)	--��������¼״̬
	
	If @Type = 1
	Begin
		If @Transcriptor < 1
		Begin
			Set @ErrNum = 201
			Set @ErrMsg = '��¼��Ա��Ϣ�����ڣ������µ�½'
			Goto theEnd
		End
	End
	If @Type = 3
	Begin
		
		If @TranscriptionCheck < 1
		Begin
			Set @ErrNum = 201
			Set @ErrMsg = 'ȷ����Ա��Ϣ�����ڣ������µ�½'
			Goto theEnd
		End
		
	End
	If Exists(Select Top 1 1 From Transcription Where CaseCode = @CaseCode)		--�޸Ĳ���
	Begin
		Select @oStatus = Status From Transcription Where CaseCode = @CaseCode
		If @Type = 1		--����
		Begin
			If @oStatus = '08'--��ȷ��
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '��¼��ȷ�ϣ����ܽ��б������'
				Goto theEnd
			End
			
			Set @Status = '05'
		End
		Else If @Type = 2	--�ύ
		Begin
			If @oStatus = '08'--��ȷ��
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '��¼��ȷ�ϣ����ܽ����ύ����'
				Goto theEnd
			End
			
			select @TranscriptionCheck=UserCode from t_CaseInfo 
			left outer join t_User on UserName=JudgeId 
			Where CaseCode = @CaseCode
			Update Transcription Set TranscriptionCheck=@TranscriptionCheck Where CaseCode = @CaseCode
			Set @Status = '06'
		End
		Else If @Type = 3	--ȷ��
		Begin
			Select @oClerkId = ClerkId From t_CaseInfo Where CaseCode = @CaseCode
			If @UserID <> @oClerkId
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '�����Ǹð������Ա�����ܽ��д˲���'
				Goto theEnd
			End
			If @oStatus = '04'--δ��¼
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '��δ��¼��Ϣ�����ܽ���ȷ�ϲ���'
				Goto theEnd
			End
			If @oStatus = '05'--��¼��
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '��Ϣ����¼�У����ܽ���ȷ�ϲ���'
				Goto theEnd
			End
			If @oStatus = '08'--��ȷ��
			Begin
				Set @ErrNum = 101
				Set @ErrMsg = '��¼��ȷ�ϣ�����Ҫ�ٴν���ȷ��'
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
			Set @ErrMsg = '�����¼��Ϣ�������������²���'
			Goto theEnd
		End
	End
	Else																			--��Ӳ���
	Begin
		Insert Into Transcription(CaseCode,TranscriptionContent,Transcriptor,Status,SubmitTime) 
		 Values(@CaseCode,@TranscriptionContent,@Transcriptor,'05',GETDATE())
		If @@ERROR <> 0
		Begin
			Set @ErrNum = 201
			Set @ErrMsg = '�����¼��Ϣ�������������²���'
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