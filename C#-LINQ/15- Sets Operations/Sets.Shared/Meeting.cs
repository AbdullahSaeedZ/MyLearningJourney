namespace Sets.Shared;

public class Meeting
{
    public string Title { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartAt { get; set; }
    public TimeOnly EndAt { get; set; }
    public List<Employee> Participants { get; set; } = new();

    public override string ToString()
    {
        string participantsList = "";

        int length = Participants.Count;
        for (int i = 0; i < length; i++)
        {
            string branchSymbol = i < length - 1 ? "├" : "└";
            participantsList += $"\n\t\t{branchSymbol}── {Participants[i]}";
        }

        return $"\n\t┌ {Date.ToString("D")} [{StartAt.ToString("hh:mm")} - {EndAt.ToString("hh:mm")}] '{Title}' ({length})" +
               $"\n\t└────" +
               $"{participantsList}";
    }
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (this.GetType() != obj.GetType()) return false;

        var other = (Meeting)obj;
        return Title == other.Title
               && Date == other.Date
               && EndAt == other.EndAt
               && StartAt == other.StartAt
               && Participants.SequenceEqual(other.Participants);
    }
    
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Title.GetHashCode();
        hash = hash * 23 + StartAt.GetHashCode();
        hash = hash * 23 + EndAt.GetHashCode();
        hash = hash * 23 + Date.GetHashCode();
        return hash;
    }
}