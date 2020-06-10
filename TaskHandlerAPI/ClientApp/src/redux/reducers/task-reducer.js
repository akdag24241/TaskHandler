const initState = {
    name: "",
    base64FileContent: "",
    description: "",
    runPeriodId: 0,
    runPeriodValue: 0
}

const taskReducer = (state = initState, action) => {
    switch (action.type) {
        case "SAVE_TASK":
            console.log("Your task was saved ..", action.payload);
            return state;
        default:
            return state;
    }
}

export default taskReducer;