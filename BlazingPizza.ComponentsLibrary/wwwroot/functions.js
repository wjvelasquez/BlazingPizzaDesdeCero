(
    function () {
        window.blazorJSFunctions =
        {
            focus: (selector) =>
            {
                var element = document.querySelector(selector)
                if (element)
                {
                    element.focus();
                };
            },
            getLocalStorage: key => key in localStorage ? JSON.parse(localStorage[key]) : null,
            setLocalStorage: (key, value) => localStorage[key] = JSON.stringify(value),
            deleteLocalStorage: key => delete localStorage[key]
        };
    }
)();