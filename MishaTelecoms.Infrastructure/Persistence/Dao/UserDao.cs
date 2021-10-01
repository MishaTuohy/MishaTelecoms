using MishaTelecoms.Application.Interfaces.Dao;

namespace MishaTelecoms.Infrastructure.Persistence.Dao
{
    public class UserDao : IUserDao
    {
        public string InsertSql()
        {
            return @"INSERT INTO [dbo].[ApplicationUser] ([Id], [UserName], [NormalizedUserName], [Email],
                    [NormalizedEmail], [EmailConfirmed], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled])
                    VALUES (@Id, @UserName, @NormalizedUserName, @Email, @NormalizedEmail, @EmailConfirmed, @PasswordHash, @PhoneNumber, 
                    @PhoneNumberConfirmed, @TwoFactorEnabled);
                    SELECT SCOPE_IDENTITY()";
        }
        public string DeleteSql()
        {
            return @"DELETE FROM [dbo].[ApplicationUser] 
                   WHERE Id = @Id";
        }
        public string GetAllSql()
        {
            return @"Select * From [dbo].[ApplicationUser]";
        }
        public string GetByIdSql()
        {
            return @"SELECT * FROM [dbo].[ApplicationUser]
                   WHERE [Id] = @Id";
        }
        public string GetByNameSql()
        {
            return @"SELECT * FROM [dbo].[ApplicationUser]
                   WHERE [UserName] = @UserName";
        }
        public string GetByEmailSql()
        {
            return @"SELECT * FROM [ApplicationUser]
                   WHERE [Email] = @Email";
        }
        public string GetByPhoneNumberSql()
        {
            return @"SELECT * FROM [dbo].[ApplicationUser]
                   WHERE [PhoneNumber] = @PhoneNumber";
        }
        public string UpdateSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] SET
                    [UserName] = @UserName,
                    [NormalizedUserName] = @NormalizedUserName,
                    [Email] = @Email,
                    [NormalizedEmail] = @NormalizedEmail,
                    [EmailConfirmed] = @EmailConfirmed,
                    [PasswordHash] = @PasswordHash,
                    [PhoneNumber] = @PhoneNumber,
                    [PhoneNumberConfirmed] = @PhoneNumberConfirmed,
                    [TwoFactorEnabled] = @TwoFactorEnabled
                    WHERE [Id] = @Id";
        }
        public string UpdateUserNameSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] 
                    SET UserName = @UserName
                    WHERE Id = @Id";
        }
        public string UpdateNormalizedUserNameSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] 
                    SET NormalizedUserName = @NormalizedUserName
                    WHERE Id = @Id";
        }
        public string UpdateEmailSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] 
                    SET Email = @Email
                    WHERE Id = @Id";
        }
        public string UpdateNormalizedEmailSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] 
                    SET NormalizedEmail = @NormalizedEmail
                    WHERE Id = @Id";
        }
        public string UpdateEmailConfirmedSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] 
                    SET EmailConfirmed = @EmailConfirmed
                    WHERE Id = @Id";
        }
        public string UpdatePhoneNumberSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] 
                    SET PhoneNumber = @PhoneNumber
                    WHERE Id = @Id";
        }
        public string UpdatePhoneNumberConfirmedSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] 
                    SET PhoneNumberConfirmed = @PhoneNumberConfirmed
                    WHERE Id = @Id";
        }
        public string UpdatePasswordHashSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] 
                    SET PasswordHash = @PasswordHash
                    WHERE Id = @Id";
        }
        public string UpdateTwoFactorEnabledSql()
        {
            return @"UPDATE [dbo].[ApplicationUser] 
                    SET TwoFactorEnabled = @TwoFactorEnabled
                    WHERE Id = @Id";
        }
    }
}
