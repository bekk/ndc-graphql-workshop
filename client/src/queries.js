import gql from "graphql-tag";

export const GET_CHARACTERS = gql`{
    characters {
        id
        name
        image
    }
}`;