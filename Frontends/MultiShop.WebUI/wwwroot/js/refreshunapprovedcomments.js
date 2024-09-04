$('#uacomment').click(function (event) {    
    kvm = setInterval(function () {
        $("#getuacomment").load("/Admin/AdminLayout/Refreshcomment");
    }, 500)
    setTimeout(() => { clearInterval(kvm); }, 800);
});