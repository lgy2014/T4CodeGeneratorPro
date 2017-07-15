CREATE PROCEDURE  [dbo].[up_QueryPage]  
@sql varchar(2000),@start int, @end int 
as  
 begin 
     declare @pageSize int
     declare @ipage int
     declare @rcount int 
     declare @execsql varchar(2000)
     declare @sql1 varchar(2000) 
     declare @t int,@p int,@n int,@l int
    
     begin
         set @pageSize=@end-@start
         set @sql1=@sql
         set @n=0
         set @l=0
         set @t=charindex('select ',lower(@sql))
         set @sql=substring(@sql,@t+7,len(@sql)-7)
         set @n=@n+1
         set @l=@l+7
         
         while(@n!=0)
         begin
             set @t=charindex('select ',lower(@sql))
             set @p=charindex('from ',lower(@sql))
             if ((@t<@p) and (@t!=0))
                 begin
                     set @sql=substring(@sql,@t+7,len(@sql)-7)
                     set @n=@n+1
                     set @l=@l+6+@t
                 end
             else
                 begin
                     set @sql=substring(@sql,@p+5,len(@sql)-5)
                     set @n=@n-1
                     set @l=@l+4+@p
                 end
         end
         set @execsql = substring(@sql1,1,@l-5)+' ,sybid=identity(12) into #temp '+substring(@sql1,@l-4,len(@sql1)-@l+5)
         select @rcount=@start + @pageSize
         set rowcount @rcount 
         set @execsql = @execsql + ' select * from #temp where sybid>' + convert(varchar,@start) + ' and sybid <= ' 
         + convert(varchar,@rcount) 
         print @execsql
         execute (@execsql) 
         set rowcount 0 
     end
 end