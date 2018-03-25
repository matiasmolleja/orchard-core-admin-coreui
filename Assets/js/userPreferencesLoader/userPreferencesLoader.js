// We add some classes to the body tag to restore the sidebar to the state is was before reload.
// That state was saved to localstorage by userPreferencesPersistor.js
// We need to apply the classes before the page is rendered. 
// That is why we use a MutationObserver instead of document.Ready().
var observer = new MutationObserver(function (mutations) {
    for (var i = 0; i < mutations.length; i++) {
        for (var j = 0; j < mutations[i].addedNodes.length; j++) {
            if (mutations[i].addedNodes[j].tagName == 'BODY') {

                var body = mutations[i].addedNodes[j];

                var coreUIPreferences = JSON.parse(localStorage.getItem('coreUIPreferences'));
                if (coreUIPreferences != null) {
                    if (coreUIPreferences.sidebarMinimized == true) {
                        body.className += ' sidebar-minimized';
                    }

                    if (coreUIPreferences.sidebarMinimized == true) {
                        body.className += ' brand-minimized';
                    }

                    if (coreUIPreferences.sidebarHidden == true) {
                        body.className += ' sidebar-hidden';
                    }
                }
                // we're done: 
                observer.disconnect();
            };
        }
    }
});

observer.observe(document.documentElement, {
    childList: true,
    subtree: true
});