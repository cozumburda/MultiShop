$('#urmessage').click(function (event) {    
    kvm = setInterval(function () {
        $("#geturmessage").load("/Admin/AdminLayout/RefreshMessage");
    }, 500)
    setTimeout(() => { clearInterval(kvm); }, 800);
});