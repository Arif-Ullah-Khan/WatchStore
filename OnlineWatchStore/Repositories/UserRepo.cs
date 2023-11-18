using OnlineWatchStore.Models;
using OnlineWatchStore.ViewModels;

namespace OnlineWatchStore.Repositories
{
    public class UserRepo
    {
        public WatchStoreDbContext context;
        public UserRepo(WatchStoreDbContext context)
        {
            this.context = context;
        }

        public void GetAllUsers(UserVM vm)
        {
            vm.UserList = context.Users.ToList();
        }
        public void GetSpecficUser(int id, UserVM vm)
        {
            vm.UserItem = context.Users.Where(x => x.UserId == id).FirstOrDefault();

        }
        public int AddNewUser(UserVM vm)
        {
            try
            {
                var checkphone = context.Users.Where(x => x.Phone == vm.UserItem.Phone).Count();
                if (checkphone == 0)
                {
                    var checkusername = context.Users.Where(x => x.Username == vm.UserItem.Username).Count();
                    if (checkusername == 0)
                    {
                        var entity = new User
                        {
                            Name = vm.UserItem.Name,
                            Email = vm.UserItem.Email,
                            Username = vm.UserItem.Username,
                            Password = vm.UserItem.Password,
                            Phone = vm.UserItem.Phone,
                            Address = vm.UserItem.Address
                        };

                        context.Users.Add(entity);
                        context.SaveChanges();

                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public int UpdateUser(UserVM vm)
        {

            try
            {
                var checkphone = context.Users.Where(x => x.Phone == vm.UserItem.Phone && x.UserId != vm.UserItem.UserId).Count();
                if (checkphone == 0)
                {
                    var checkusername = context.Users.Where(x => x.Username == vm.UserItem.Username && x.UserId != vm.UserItem.UserId).Count();
                    if (checkusername == 0)
                    {
                        var findentity = context.Users.Where(x => x.UserId == vm.UserItem.UserId).FirstOrDefault();
                        if (findentity != null)
                        {
                            findentity.Name = vm.UserItem.Name;
                            findentity.Email = vm.UserItem.Email;
                            findentity.Username = vm.UserItem.Username;
                            findentity.Password = vm.UserItem.Password;
                            findentity.Address = vm.UserItem.Address;
                            findentity.Phone = vm.UserItem.Phone;
                            context.Users.Update(findentity);
                            context.SaveChanges();

                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                    
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
