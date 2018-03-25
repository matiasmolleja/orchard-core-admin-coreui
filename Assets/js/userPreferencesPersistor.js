// Each time the sidebar status is modified, that is persisted to localStorage.
// The next load of the page, userPreferencesLoader.js will read that info to 
// restore the sidebar to the previous state.
function persistCoreUIAdminPreferences() {
    setTimeout(function () {

        var body = document.getElementsByTagName('body');

        var coreUIPreferences = {};
        coreUIPreferences.sidebarMinimized = $('body').hasClass('sidebar-minimized') ? true : false;
        coreUIPreferences.brandMinimized = $('body').hasClass('brand-minimized') ? true : false;
        coreUIPreferences.sidebarHidden = $('body').hasClass('sidebar-hidden') ? true : false;

        localStorage.setItem('coreUIPreferences', JSON.stringify(coreUIPreferences));

    }, 200);
}

// Triggers
$('.sidebar-toggler').click(function () {
    persistCoreUIAdminPreferences();
});

$('.sidebar-minimizer').click(function () {
    persistCoreUIAdminPreferences();    
});

$('.brand-minimizer').click(function () {
    persistCoreUIAdminPreferences();
});

//  Not implemented yet
//$('.aside-menu-toggler').click(function () {
//    persistCoreUIAdminPreferences();    
//});

//$('.mobile-sidebar-toggler').click(function () {
//    persistCoreUIAdminPreferences();
//});

//$('.sidebar-close').click(function () {
//    persistCoreUIAdminPreferences();
//});