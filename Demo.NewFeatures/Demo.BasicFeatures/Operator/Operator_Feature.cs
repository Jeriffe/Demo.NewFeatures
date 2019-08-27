using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BasicFeatures
{
    /*
     * 使用 operator 关键字重载内置运算符，
     * 或在类或结构声明中提供用户定义的转换
     */
    class Operator_Feature
    {
        class Salary
        {
            public int RMB { get; set; }

            public static Salary operator +(Salary s1, Salary s2)
            {
                Salary s = new Salary();
                s.RMB = s2.RMB + s1.RMB;
                return s;
            }
           
            public static Salary operator -(Salary s1, Salary s2)
            {
                Salary s = new Salary();
                s.RMB = s1.RMB - s2.RMB;
                return s;
            }
        }

        /*
         * The implicit and explicit keywords in C# are used when declaring conversion operators
         */
        public class Role
        {
            public string Name { get; set; }
        }

        public class Role_IM
        {
            public string Name { get; set; }

            /// <summary>
            /// This means that we want to implicitly convert a string to a Role (since there is no specific cast involved in the code). 
            /// To achieve this, we add an implicit conversion operator:
            /// </summary>
            /// <param name="roleName"></param>
            public static implicit operator Role_IM(string roleName)
            {
                return new Role_IM { Name = roleName };
            }

            public static implicit operator string(Role_IM role)
            {
                if (role == null)
                {
                    return string.Empty;
                }

                return role.Name;
            }
        }

        public class Role_EX
        {
            public string Name { get; set; }

            /// <summary>
            ///  implement an explicit conversion operator
            ///  In this case, we cannot implicitly convert a string to a Role, but we need to cast it in our code
            /// </summary>
            /// <param name="roleName"></param>
            public static explicit operator Role_EX(string roleName)
            {
                return new Role_EX { Name = roleName };
            }

            public static explicit operator string(Role_EX role)
            {
                if (role == null)
                {
                    return string.Empty;
                }

                return role.Name;
            }
        }

        public static void Test()
        {
            Salary mikeIncome = new Salary() { RMB = 22 };
            Salary roseIncome = new Salary() { RMB = 33 };

            Salary familyIncome = mikeIncome + roseIncome;
            Console.WriteLine(familyIncome.RMB);

            Salary subtractIncome = mikeIncome - roseIncome;
            Console.WriteLine(subtractIncome.RMB);



            Role role = new Role();
            role.Name = "RoleName";


            Role_IM r_im = new Role_IM { Name = "ROLE_IM" };
            string role_im_name = r_im;
            r_im = "ROLE_IM2";

            Console.WriteLine(role_im_name);
            Console.WriteLine(r_im.Name);


            Role_EX r_ex = new Role_EX { Name = "ROLE_EX" };
            string role_ex_name = (string)r_ex;
            r_ex = (Role_EX)"ROLE_EX2";

            Console.WriteLine(role_ex_name);
            Console.WriteLine(r_ex.Name);

        }
    }
}
