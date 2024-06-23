using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuestions.Classes;
public static class ControlExtensions
{
    /// <summary>
    /// Base method for obtaining controls on a form or within a container like a panel or group box
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="control"></param>
    /// <returns></returns>
    public static IEnumerable<T> Descendants<T>(this Control control) where T : class
    {
        foreach (Control child in control.Controls)
        {
            if (child is T thisControl)
            {
                yield return (T)thisControl;
            }

            if (child.HasChildren)
            {
                foreach (T descendant in Descendants<T>(child))
                {
                    yield return descendant;
                }
            }
        }
    }
    /// <summary>
    /// Get selected/checked RadioButton for a control such as a panel, group box or form
    /// </summary>
    /// <param name="control">control, form, panel or group box</param>
    /// <param name="checked">True false, defaults to true</param>
    /// <returns>One checked Radio button or an empty value</returns>
    public static RadioButton RadioButtonChecked(this Control control, bool @checked = true)
        => control.Descendants<RadioButton>().ToList().FirstOrDefault((radioButton) => radioButton.Checked == @checked)!;
    /// <summary>
    /// Get all RadioButton controls from specified control
    /// </summary>
    /// <param name="control">Desired control which can be a form or a control like a panel or GroupBox on a form</param>
    /// <returns>List of RadioButton or an empty list if no RadioButton on control</returns>
    public static List<RadioButton> RadioButtonList(this Control control)
        => control.Descendants<RadioButton>().ToList();
}
