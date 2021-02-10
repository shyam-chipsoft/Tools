using System;
using System.Collections.Generic;
using System.Text;

namespace AgoraIO.Media
{
    public class RtmTokenBuilder
    {
        public sealed class Role
        {
            public static readonly Role Rtm_User = new Role("Rtm_User", InnerEnum.Rtm_User, 1);

            private static readonly List<Role> valueList = new List<Role>();

            static Role()
            {
                valueList.Add(Rtm_User);
            }

            public enum InnerEnum
            {
                Rtm_User
            }

            public readonly InnerEnum innerEnumValue;
            private readonly string nameValue;
            private readonly int ordinalValue;
            private static int nextOrdinal = 0;

            internal int value;
            internal Role(string name, InnerEnum innerEnum, int value)
            {
                this.value = value;

                nameValue = name;
                ordinalValue = nextOrdinal++;
                innerEnumValue = innerEnum;
            }

            public static Role[] values()
            {
                return valueList.ToArray();
            }

            public int ordinal()
            {
                return ordinalValue;
            }

            public override string ToString()
            {
                return nameValue;
            }

            public static Role valueOf(string name)
            {
                foreach (Role enumInstance in Role.valueList)
                {
                    if (enumInstance.nameValue == name)
                    {
                        return enumInstance;
                    }
                }
                throw new System.ArgumentException(name);
            }
        }

        public AccessToken mTokenCreator;

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public String buildToken(String appId, String appCertificate, String uid, Role role, int privilegeTs) throws Exception
        public virtual string buildToken(string appId, string appCertificate, string uid, Role role, uint privilegeTs)
        {
            mTokenCreator = new AccessToken(appId, appCertificate, uid, "");
            mTokenCreator.addPrivilege(Privileges.kRtmLogin, privilegeTs);
            return mTokenCreator.build();
        }

        public virtual void setPrivilege(Privileges privilege, uint expireTs)
        {
            mTokenCreator.addPrivilege(privilege, expireTs);
        }
    }
}

