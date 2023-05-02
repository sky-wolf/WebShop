import { apiSlice } from "./apiSlice";

export const authApiSlice = apiSlice.injectEndpoints({
    endpoints: builder => ({
        login: builder.mutation({
            query: Credentials => ({
                url: '/auth',
                method: 'POST',
                body: { ...Credentials }
            })
        }),
        
    })
})