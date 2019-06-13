import React, { useState } from 'react';
import { withRouter } from 'react-router-dom';

const Push = ({ name }) => {
  const pushFromWindow = () => {}; // ToDo: Task 4b - impl GraphQl mutation function

  return (
    <button
      onClick={() => {
        pushFromWindow(); // ToDo: Task 4b - add input parameters
        window.location.reload();
      }}
    >
      Push
    </button>
  );
};

const AddTitle = ({ name }) => {
  const [titleInput, setTitleInput] = useState('');

  const addTitle = () => {}; // ToDo: Task 4d - impl GraphQl mutation function

  return (
    <div>
      <input type="text" value={titleInput} onChange={event => setTitleInput(event.currentTarget.value)} />
      <button
        onClick={() => {
          addTitle(); // ToDo: Task 4d - add input parameters
          window.location.reload();
        }}
      >
        Add title
      </button>
    </div>
  );
};

const View = ({ character }) => {
  const { name, image, titles, isHealthy = true } = character;

  return (
    <section className="character">
      <h1>{name}</h1>
      <div className="character-info">
        <div className="character-image">
          <img src={image} alt="" className="image-large" />
          {!isHealthy && <div className="hurt">IS HURTING</div>}
        </div>
        <div className="characteristics">
          <strong>Titles:</strong>
          {titles.length === 0 && <span> No titles</span>}
          {titles.length > 0 && (
            <ul>
              {titles.map(title => (
                <li>{title}</li>
              ))}
            </ul>
          )}
        </div>
      </div>
      <div className="character-actions">
        <AddTitle name={name} />
        <Push name={name} />
      </div>
    </section>
  );
};

class Character extends React.Component {
  render() {
    const paramName = this.props.match.params.name;

    // ToDo: Task 3d - get character from GraphQL server by 'paramName' from URL
    const character = {
      name: 'Unknown',
      titles: [],
      image: undefined
    };

    return <View character={character} />;
  }
}

export default withRouter(Character);
