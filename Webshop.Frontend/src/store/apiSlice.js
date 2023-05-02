import {createApi, fetchBaseQuery } from '@reduxjs/toolkit';
import { setCredentials, logOut } from './auth-slice';

const baseQuery = fetchBaseQuery({
    baseUrl: 'http://localhost:1919',
    Credentials: 'include',
    prepareHeaders: (headers, {getState}) =>{
        const token = getState().auth.token;
        if(token)
        {
            headers.set("authorization", `Bearer ${token}`);
        }
        return headers;
    }

});

const baseQueryWithReauth = async(args, api, extraOptions) => {
    let result = await baseQuery(args, api, extraOptions);

    if(result?.error?.originalStatus === 403){
        console.log('sending refresh token');

        const refreshResult = await baseQuery('/refresh', api, extraOptions);
        console.log(refreshResult);
        if(refreshResult?.data)
        {
            const user = api.getState().auth.user;
            //store the new token
            api.dispatch(setCredentials({...refreshResult.data, user}))
            //retry the original query with new access token
            result = await baseQuery(args, api, extraOptions);
        }else{
            api.dispatch(logOut());
        }
    }
    return result;
};

export const apiSlice = createApi({
    baseQuery: baseQueryWithReauth,
    endpoints: builder => ({})

})