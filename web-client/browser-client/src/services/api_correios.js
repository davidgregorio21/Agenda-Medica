import axios from 'axios';
import { getToken } from './auth';

const api = axios.create({
    baseURL: 'https://viacep.com.br/ws/'
});

const api_correios = async cep => {
	try {
    const response = await api.get(`${cep}/json/`);
    console.log(response.data.logradouro);
  } catch (error) {
    console.error(error);
  }
}

export default api_correios;
