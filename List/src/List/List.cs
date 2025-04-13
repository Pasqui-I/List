namespace List.src.List{
    public interface IList<T>{
        public INode<T> Head {get; set;}

        public void Add(T NewValue);
        public void Remove(T ValueToRemove);
        public bool IsPresent(T ValueToFind);
        public bool IsEmpty();
        public string ToString();
    }
}