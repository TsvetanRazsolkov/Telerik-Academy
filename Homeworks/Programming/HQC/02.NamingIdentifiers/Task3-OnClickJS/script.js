function showIfBrowserIsMozilla() {
    var userWindow = window,
        userBrowser = userWindow.navigator.appCodeName,
        isMozilla = userBrowser === 'Mozilla';

    if (isMozilla) {
        alert('Yes, browser is Mozilla');
    }
    else {
        alert('No, browser is not Mozilla');
    }
}