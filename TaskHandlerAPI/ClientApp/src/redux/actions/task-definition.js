export const saveTask = (task) => {
    return (dispatch, getState) => {
        console.log(JSON.stringify(task));
        let response = postData('/api/taskdefinition/savetask', task);
        console.log(task);         

        console.log(response);

        dispatch({
            type: "SAVE_TASK",
            payload: task
        });

    }
}


// Example POST method implementation:
async function postData(url = '', data = {}) {
    // Default options are marked with *
    const response = await fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json',
            'Accept':'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
            //'Content-Type': 'multipart/form-data'
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *client
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    });
    return await response.json(); // parses JSON response into native JavaScript objects
}
