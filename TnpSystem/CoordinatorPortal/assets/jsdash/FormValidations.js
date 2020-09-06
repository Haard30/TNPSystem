function validateRange() {

    var txtvalue = document.getElementById("<%=txt_value.ClientID%>").value;

    //value from aspx.cs file
    var valfromDb = "<%=valuefromDb%>"

    if (txtvalue > 600) {
        alert('Typed value is greater than 600 value');

        txtvalue.SetFocus();
        return false;
    }
    else if (txtvalue < 100) {
        alert('Typed value is less than 100 value');

        txtvalue.SetFocus();

        return false;
    }
    else
        return true;

}