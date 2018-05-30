namespace Monitor.Domain.ViewModel
{
    public class ApiVm
    {
        public int Id { get; set; }
        public string HttpMethod { get; set; }
        public string Uri { get; set; }

        public string Name
        {
            get { return string.Format("[{0}] {1}", this.HttpMethod, this.Uri); }
        }
    }
}