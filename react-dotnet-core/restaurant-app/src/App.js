import logo from './logo.svg';
import './App.css';
import { Container, Typography } from '@mui/material';
import Order from './components/Order';

function App() {
  return (
    <Container maxWidth="md">
      <Typography variant="h2" align="center" gutterBottom>Restaurant App</Typography>
      <Order />
    </Container>
  );
}

export default App;
