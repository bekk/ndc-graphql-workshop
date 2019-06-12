import gql from 'graphql-tag';

export const GET_CHARACTERS = gql`
  {
    characters {
      id
      name
      image
    }
  }
`;

export const GET_CHARACTER = gql`
  query getCharacter($name: String!) {
    character(name: $name) {
      id
      name
      image
      titles
      isHealthy
    }
  }
`;

export const ADD_CHARACTER_TITLE = gql`
  mutation addTitle($name: String!, $title: String!) {
    addTitle(name: $name, title: $title) {
      titles
    }
  }
`;

export const PUSH_CHARACTER = gql`
  mutation pushFromWindow($name: String!) {
    pushFromWindow(name: $name) {
      isHealthy
    }
  }
`;
