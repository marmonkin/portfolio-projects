using UnityEngine;

public class ShowIfAttribute : PropertyAttribute
{
    public string conditionalField;

    public ShowIfAttribute(string booleanFieldName)
    {
        this.conditionalField = booleanFieldName;
    }
}