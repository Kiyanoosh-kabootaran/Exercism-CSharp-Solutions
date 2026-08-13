abstract class Character
{
    private string characterType;
    protected bool prepared = false;
    
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        
        return false;
            
    }

    public override string ToString()
    {
        return $"Character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        bool vulnerable = target.Vulnerable();

        return vulnerable ? 10 : 6 ;
    }
}

class Wizard : Character
{
    public Wizard() : base("Wizard")
    {
    }

    public override bool Vulnerable()
    {
        
        return prepared == false ? true : false ;
            
    }

    public override int DamagePoints(Character target)
    {
        return prepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        prepared = true;
    }
}
