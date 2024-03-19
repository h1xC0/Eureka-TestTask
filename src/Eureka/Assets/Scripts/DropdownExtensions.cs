public static class DropdownExtensions
{
    /// <summary>
    /// Call this after modifying options while the dropdown is displayed
    /// to make sure the visual is up to date.
    /// </summary>
    public static void RefreshOptions(this TMPro.TMP_Dropdown dropdown)
    {
        dropdown.enabled = false;
        dropdown.enabled = true;
        dropdown.Show();
    }
}
