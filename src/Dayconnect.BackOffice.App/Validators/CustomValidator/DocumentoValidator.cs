namespace DevSecOps.backoffice.App.Validators.CustomValidator;

public static class DocumentoValidator
{
    public static bool ValidarDocumento(string documento)
    {
        if (string.IsNullOrEmpty(documento))
            return false;

        return ValidaCpf(documento) || ValidaCnpj(documento);
    }

    private static bool ValidaCpf(string vrCpf)
    {
        if (string.IsNullOrEmpty(vrCpf))
            return false;
        try
        {
            var valor = vrCpf.Replace(".", "").Replace("-", "").Replace(" ", "").Trim();
            if (valor.Length != 11)
                return false;
            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao valida o CPF.", ex);
        }
    }

    private static bool ValidaCnpj(string cnpj)
    {
        if (string.IsNullOrEmpty(cnpj))
            return false;

        try
        {
            var multiplicador1 = new[] {5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};
            var multiplicador2 = new[] {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            var tempCnpj = cnpj.Substring(0, 12);
            var soma = 0;

            for (var i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            var resto = (soma % 11);

            resto = resto < 2 ? 0 : 11 - resto;

            var digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (var i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto;

            return cnpj.EndsWith(digito);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao validar o CNPJ.", ex);
        }
    }
}