create procedure [dbo].[up_GetTodoNumber]
	@UserCode int
as
begin
	declare @TranscriptionSave smallint --1-��¼����Ȩ��
	select @TranscriptionSave=0
	
	declare @TranscriptionSubmit smallint --1-��¼�ύȨ��
	select @TranscriptionSubmit=0
	
	declare @TranscriptionConfirmation smallint --1-��¼ȷ��Ȩ��
	select @TranscriptionConfirmation=0
	
	if exists(	select 1 from t_Authority as a 
                where a.RoleCode in(select ur.RoleCode from t_user_role as ur where ur.UserCode=@UserCode) and AuthorityValue='_Transcription_Save_'
		)
		select @TranscriptionSave=1
	
	if exists(	select 1 from t_Authority as a 
                where a.RoleCode in(select ur.RoleCode from t_user_role as ur where ur.UserCode=@UserCode) and AuthorityValue='_Transcription_Submit_'
		)
		select @TranscriptionSubmit=1
	
	if exists(	select 1 from t_Authority as a 
                where a.RoleCode in(select ur.RoleCode from t_user_role as ur where ur.UserCode=@UserCode) and AuthorityValue='_Transcription_Confirmation_'
		)
		select @TranscriptionConfirmation=1
	
	declare @TodoNumber int --�������
	select @TodoNumber=0
	if(@TranscriptionConfirmation=1)
	select @TodoNumber=@TodoNumber+COUNT(1) from t_CaseAudio as ca
	left outer join Transcription as t on t.CaseCode=ca.CaseId
	where t.TranscriptionCheck=@UserCode and ca.Flag_Transcribe='06'
	
	if(@TranscriptionSave=1 or @TranscriptionSubmit=1)
	select @TodoNumber=@TodoNumber+COUNT(1) from t_CaseAudio as ca
	left outer join Transcription as t on t.CaseCode=ca.CaseId
	where (ca.Flag_Transcribe='04' or ca.Flag_Transcribe='05' or ca.Flag_Transcribe='09')
	
	select TodoNumber=isnull(@TodoNumber,0)
end