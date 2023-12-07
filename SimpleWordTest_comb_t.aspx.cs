using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SimpleWordTest_comb_t : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
        }
    }


    protected int CurrentPageIndex
    {
        get
        {
            if (ViewState["CurrentPageIndex"] != null)
                return Convert.ToInt32(ViewState["CurrentPageIndex"]);
            else
                return 0;
        }
        set
        {
            ViewState["CurrentPageIndex"] = value;
        }
    }
    protected void BindDropDownList()
    {
        
        int startIndex = CurrentPageIndex * 10;
        SqlDataSource1.SelectCommand = $"SELECT * FROM [gept_words] ORDER BY [Id] OFFSET {startIndex} ROWS FETCH NEXT 10 ROWS ONLY";
        CBF110002_DDL1.DataBind();
    }
    protected void CBF110002_PreviousButton_Click(object sender, EventArgs e)
    {
        if (CurrentPageIndex > 0)
        {
            CurrentPageIndex--;
            BindDropDownList();
            if (CurrentPageIndex == 0)
            {
                CBF110002_PreviousButton.Enabled = false;
            }
            if (CBF110002_DDL1.Items.Count == 10)
                {
                CBF110002_NextButton.Enabled = true;
            }
        }


    }



    protected void CBF110002_NextButton_Click(object sender, EventArgs e)
    {
        CurrentPageIndex++;
        BindDropDownList();

        int totalRowCount = GetTotalRowCount();
        int startIndex = (CurrentPageIndex + 1) * 10;


        if (startIndex !=0)
        {
            CBF110002_PreviousButton.Enabled = true;
        }
        if (CBF110002_DDL1.Items.Count!=10)
        {
            CBF110002_NextButton.Enabled = false;
        }



    }

    private int GetTotalRowCount()
    {

        return 0; 
    }
    protected void CBF110002_DDL1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CBF110002_cambridge.Text += CBF110002_DDL1.SelectedItem + " =>" + CBF110002_DDL1.SelectedValue + "<br />";

    }
    protected void CBF110002_GV1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        BindDropDownList();
    }

    protected void CBF110002_testBtn_Click(object sender, EventArgs e)
    {
        CBF110002_MV1.ActiveViewIndex = 1;
    }


    protected void CBF110002_nextQBtn_Click(object sender, EventArgs e)
    {

    }
}