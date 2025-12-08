using System.Reflection;

namespace ProxyPatternDependencies
{
    public class Classes
    {
        public interface IPerson
        {
            string GetName();
            string GetGender();
            string GetInterests();
            int GetGeekRating();
            void SetName(string name);
            void SetGender(string gender);
            void SetInterests(string interests);
            void SetGeekRating(int rating);
        }

        public class PersonImpl : IPerson
        {
            private string _name = String.Empty;
            private string _gender = String.Empty;
            private string _interests = String.Empty;
            private int _rating;
            private int _ratingCount;

            public string GetName() => _name;
            public string GetGender() => _gender;
            public string GetInterests() => _interests;
            public int GetGeekRating() => _ratingCount == 0 ? 0 : _rating/_ratingCount;
            public void SetName(string name) => _name = name;
            public void SetGender(string gender) => _gender = gender;
            public void SetInterests(string interests) => _interests = interests;
            public void SetGeekRating(int rating)
            {
                _rating += rating;
                _ratingCount++;
            }
        }

        public class OwnerInvocationHandler : DispatchProxy
        {
            private IPerson? _person;

            public OwnerInvocationHandler() { }

            public OwnerInvocationHandler(IPerson person)
            {
                _person = person;
            }

            public void SetPerson(IPerson person) => _person = person;

            protected override object Invoke(MethodInfo targetMethod, object[] args)
            {
                try
                {
                    if (targetMethod.Name.Equals("SetGeekRating"))
                    {
                        throw new UnauthorizedAccessException("You are not permitted to set the Geek rating");
                    }
                    return targetMethod.Invoke(_person, args);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException ?? ex;
                }
            }
        }

        public class NonOwnerInvocationHandler : DispatchProxy
        {
            private IPerson? _person;

            public NonOwnerInvocationHandler() { }

            public NonOwnerInvocationHandler(IPerson person)
            {
                _person = person;
            }

            public void SetPerson(IPerson person) => _person = person;

            protected override object Invoke(MethodInfo targetMethod, object[] args)
            {
                try
                {
                    if (!targetMethod.Name.Equals("SetGeekRating") && targetMethod.Name.StartsWith("Set"))
                    {
                        throw new UnauthorizedAccessException("You are not permitted to perform this operation");
                    }
                    return targetMethod.Invoke(_person, args);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException ?? ex;
                }
            }
        }

        public static IPerson GetOwnerProxy(IPerson person)
        {
            var proxy = DispatchProxy.Create<IPerson, OwnerInvocationHandler>();
            ((OwnerInvocationHandler)(object)proxy).SetPerson(person);
            return proxy;
        }

        public static IPerson GetNonOwnerProxy(IPerson person)
        {
            var proxy = DispatchProxy.Create<IPerson, NonOwnerInvocationHandler>();
            ((NonOwnerInvocationHandler)(object)proxy).SetPerson(person);
            return proxy;
        }

    }
}
