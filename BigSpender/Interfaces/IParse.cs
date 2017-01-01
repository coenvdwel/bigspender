using BigSpender.Objects;

namespace BigSpender.Interfaces
{
  interface IParse
  {
    bool IsValid(string path);
    void Parse(Manager manager, string path);
  }
}