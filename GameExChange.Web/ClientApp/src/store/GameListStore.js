const requestGameListData = 'REQUEST_GAME_LIST_DATA';
const receiveGameListData = 'RECEIVE_GAME_LIST_DATA';

const initialState = { results: [], isLoading: false };

export const actionCreators = {
    requestGameDatas: pageIndex => async (dispatch, getState) => {
        if (pageIndex === getState().gameListStore.pageIndex) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        };

        dispatch({ type: requestGameListData, pageIndex });

        const url = `api/Game/getList?pageindex=${pageIndex}`;
        const response = await fetch(url);
        const results = await response.json();
        console.log(results);
        dispatch({ type: receiveGameListData, pageIndex, results });
    },
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestGameListData) {
        return {
            ...state,
            pageIndex: action.pageIndex,
            isLoading: true
        };
    }

    if (action.type === receiveGameListData) {
        console.log("action");
        console.log(action);
        return {
            ...state,
            pageIndex: action.pageIndex,
            results: action.results,
            isLoading: false
        };
    }

    return state;
};
