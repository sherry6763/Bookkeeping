
function OnSuccess() {
    alertify.success('新增成功');  
}


$.validator.addMethod("daterange", function (value, element, param) 
{
    if (value === false) {
        return true;
    }
    if (Date.parse(value) > Date.parse(param)) {
        return false;
    } else {
        return true;
    }
});
$.validator.unobtrusive.adapters.addSingleVal("daterange", "input");


   