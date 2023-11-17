using System.Diagnostics;
using System.Text;
class Estudante
{
    private int matricula, coeficienteRendimento, periodoAtual;
    public Estudante[] vetor1 = new Estudante[500];
    public Estudante[] vetor2 = new Estudante[1000];
    public Estudante[] vetor3 = new Estudante[5000];
    public Estudante[] vetor4 = new Estudante[15000];
    public Estudante[] vetor1copy = new Estudante[500];
    public Estudante[] vetor2copy = new Estudante[1000];
    public Estudante[] vetor3copy = new Estudante[5000];
    public Estudante[] vetor4copy = new Estudante[15000];
    private string nome = "", curso = "";
    public void Construtor(int matricula, string nome, string curso, int coeficienteRendimento, int periodoAtual)
    {
        this.matricula = matricula;
        this.nome = nome;
        this.curso = curso;
        this.coeficienteRendimento = coeficienteRendimento;
        this.periodoAtual = periodoAtual;
    }
    int cont1 = 0, cont2 = 0, cont3 = 0, cont4 = 0;
    public void InserirAlunoVet1(int matricula, string nome, string curso, int coeficienteRendimento, int periodoAtual)
    {
        Estudante estudante = new Estudante();
        estudante.Construtor(matricula, nome, curso, coeficienteRendimento, periodoAtual);
        vetor1[cont1] = estudante;
        cont1++;
    }
    public void InserirAlunoVet2(int matricula, string nome, string curso, int coeficienteRendimento, int periodoAtual)
    {
        Estudante estudante = new Estudante();
        estudante.Construtor(matricula, nome, curso, coeficienteRendimento, periodoAtual);
        vetor2[cont2] = estudante;
        cont2++;
    }
    public void InserirAlunoVet3(int matricula, string nome, string curso, int coeficienteRendimento, int periodoAtual)
    {
        Estudante estudante = new Estudante();
        estudante.Construtor(matricula, nome, curso, coeficienteRendimento, periodoAtual);
        vetor3[cont3] = estudante;
        cont3++;
    }
    public void InserirAlunoVet4(int matricula, string nome, string curso, int coeficienteRendimento, int periodoAtual)
    {
        Estudante estudante = new Estudante();
        estudante.Construtor(matricula, nome, curso, coeficienteRendimento, periodoAtual);
        vetor4[cont4] = estudante;
        cont4++;
    }
    public int GetMatricula()
    { return matricula; }
    public string GetNome()
    { return nome; }
    public string GetCurso()
    { return curso; }
    public int GetCoefiente()
    { return coeficienteRendimento; }
    public int GetPeriodo()
    { return periodoAtual; }
}
class Program
{
    static StreamWriter escritorArquivo = new StreamWriter("Registros.txt", true, Encoding.UTF8);
    static Random numerosAleatorios = new Random();
    static void Main(string[] args)
    {
        Estudante estudante = new Estudante();
        Stopwatch cronometroExecucaoPrograma = new Stopwatch();
        double[,] resultadosSelecao500 = new double[3, 4];
        double[,] resultadosSelecao1k = new double[3, 4];
        double[,] resultadosSelecao5k = new double[3, 4];
        double[,] resultadosSelecao15k = new double[3, 4];
        double[,] resultadosBolha500 = new double[3, 4];
        double[,] resultadosBolha1k = new double[3, 4];
        double[,] resultadosBolha5k = new double[3, 4];
        double[,] resultadosBolha15k = new double[3, 4];
        double[,] resultadosInsercao500 = new double[3, 4];
        double[,] resultadosInsercao1k = new double[3, 4];
        double[,] resultadosInsercao5k = new double[3, 4];
        double[,] resultadosInsercao15k = new double[3, 4];
        //Gerador de atributos aleatórios
        cronometroExecucaoPrograma.Start();
        for (int i = 0; i < estudante.vetor1.Length; i++)
        {
            //vet1
            string nome = GerarString();
            string curso = GerarString();
            int matricula = numerosAleatorios.Next(11111, 99999);
            int coeficienteRendimento = numerosAleatorios.Next(0, 100);
            int periodo = numerosAleatorios.Next(1, 10);
            estudante.InserirAlunoVet1(matricula, nome, curso, coeficienteRendimento, periodo);
        }
        for (int i = 0; i < estudante.vetor2.Length; i++)
        {
            //vet2
            string nome = GerarString();
            string curso = GerarString();
            int matricula = numerosAleatorios.Next(11111, 99999);
            int coeficienteRendimento = numerosAleatorios.Next(0, 100);
            int periodo = numerosAleatorios.Next(1, 10);
            estudante.InserirAlunoVet2(matricula, nome, curso, coeficienteRendimento, periodo);
        }
        for (int i = 0; i < estudante.vetor3.Length; i++)
        {
            //vet3
            string nome = GerarString();
            string curso = GerarString();
            int matricula = numerosAleatorios.Next(11111, 99999);
            int coeficienteRendimento = numerosAleatorios.Next(0, 100);
            int periodo = numerosAleatorios.Next(1, 10);
            estudante.InserirAlunoVet3(matricula, nome, curso, coeficienteRendimento, periodo);
        }
        for (int i = 0; i < estudante.vetor4.Length; i++)
        {
            //vet4
            string nome = GerarString();
            string curso = GerarString();
            int matricula = numerosAleatorios.Next(11111, 99999);
            int coeficienteRendimento = numerosAleatorios.Next(0, 100);
            int periodo = numerosAleatorios.Next(1, 10);
            estudante.InserirAlunoVet4(matricula, nome, curso, coeficienteRendimento, periodo);
        }
        //Copiando valores para outro vetor
        Array.Copy(estudante.vetor1, estudante.vetor1copy, estudante.vetor1.Length);
        Array.Copy(estudante.vetor2, estudante.vetor2copy, estudante.vetor2.Length);
        Array.Copy(estudante.vetor3, estudante.vetor3copy, estudante.vetor3.Length);
        Array.Copy(estudante.vetor4, estudante.vetor4copy, estudante.vetor4.Length);

        //Laço para realizar cada teste 10 vezes.
        for (int j = 0; j < 10; j++)
        {
            VerificarDesempenhoSelecao(estudante.vetor1copy, resultadosSelecao500);
            VerificarDesempenhoSelecao(estudante.vetor2copy, resultadosSelecao1k);
            VerificarDesempenhoSelecao(estudante.vetor3copy, resultadosSelecao5k);
            VerificarDesempenhoSelecao(estudante.vetor4copy, resultadosSelecao15k);
        }
        for (int j = 0; j < 10; j++)
        {
            VerificarDesempenhoBolha(estudante.vetor1copy, resultadosBolha500);
            VerificarDesempenhoBolha(estudante.vetor2copy, resultadosBolha1k);
            VerificarDesempenhoBolha(estudante.vetor3copy, resultadosBolha5k);
            VerificarDesempenhoBolha(estudante.vetor4copy, resultadosBolha15k);
        }
        for (int j = 0; j < 10; j++)
        {
            VerificarDesempenhoInsercao(estudante.vetor1copy, resultadosInsercao500);
            VerificarDesempenhoInsercao(estudante.vetor2copy, resultadosInsercao1k);
            VerificarDesempenhoInsercao(estudante.vetor3copy, resultadosInsercao5k);
            VerificarDesempenhoInsercao(estudante.vetor4copy, resultadosInsercao15k);
        }
        cronometroExecucaoPrograma.Stop();
        TimeSpan time = cronometroExecucaoPrograma.Elapsed;
        string hora = String.Format("{0:00}", time.Hours);
        string minuto = String.Format("{0:00}", time.Minutes);
        string segundo = String.Format("{0:00}", time.TotalSeconds);
        //Escrever no arquivo as médias de resultados
        Escritor(resultadosSelecao500, "\nALGORITMO SELEÇÃO\n\n", "500");
        Escritor(resultadosSelecao1k, "\n\nALGORITMO SELEÇÃO\n\n", "1.000");
        Escritor(resultadosSelecao5k, "\n\nALGORITMO SELEÇÃO\n\n", "5.000");
        Escritor(resultadosSelecao15k, "\n\nALGORITMO SELEÇÃO\n\n", "15.000");
        Escritor(resultadosBolha1k, "\n\nALGORITMO BOLHA\n\n", "500");
        Escritor(resultadosBolha1k, "\n\nALGORITMO BOLHA\n\n", "1.000");
        Escritor(resultadosBolha5k, "\n\nALGORITMO BOLHA\n\n", "5.000");
        Escritor(resultadosBolha15k, "\n\nALGORITMO BOLHA\n\n", "10.000");
        Escritor(resultadosInsercao500, "\n\nALGORITMO INSERÇÃO\n\n", "500");
        Escritor(resultadosInsercao1k, "\n\nALGORITMO INSERÇÃO\n\n", "1.000");
        Escritor(resultadosInsercao5k, "\n\nALGORITMO INSERÇÃO\n\n", "5.000");
        Escritor(resultadosInsercao15k, "\n\nALGORITMO INSERÇÃO\n\n", "15.000");
        escritorArquivo.WriteLine($"\nTEMPO DE EXEUÇÃO DO PROGRAMA: {hora} Hora, {minuto} Minutos, {segundo} Segundos.");
        escritorArquivo.Close();

        try
        {
            Console.WriteLine("\n\nVocê deseja imprimir dados de algum vetor? (já ordenado)");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("(Essa ação pode não ser executada como esperado em alguns dispositivos devido ao grande tamanho dos vetores)");
            Console.ResetColor();
            Console.WriteLine("\n1)Sim\n2)Não");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                Console.WriteLine("\nQual vetor deseja vizualizar?\n1)[1.000]\n2)[10.000]\n3)[100.000]\n4)[200.000]");
                int opcao1 = int.Parse(Console.ReadLine());
                switch (opcao1)
                {
                    case 1:
                        MostrarDadosEstudante(estudante.vetor1copy, "[1.000]");
                        break;

                    case 2:
                        MostrarDadosEstudante(estudante.vetor2copy, "[10.000]");
                        break;

                    case 3:
                        MostrarDadosEstudante(estudante.vetor3copy, "[100.000]");
                        break;

                    case 4:
                        MostrarDadosEstudante(estudante.vetor4copy, "[200.000]");
                        break;

                    default:
                        Console.WriteLine("\n****OPÇÃO INVÁLIDO****");
                        break;
                }
            }
            else if (opcao == 2)
            {
                Console.WriteLine("\n****PROGRAMA ENCERRADO****\n");

            }
            else
            {
                Console.WriteLine("\n****OPÇÃO INVÁLIDA****\n");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Você digitou um caractere inválido, o menu funciona apenas com números");
        }
    }
    //Algoritmo SELEÇÃO
    static void VerificarDesempenhoSelecao(Estudante[] vet, double[,] resultadosSelecao)
    {
        //Ordenando VETOR aleatório
        Stopwatch cronometroSelecao = new Stopwatch();
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        cronometroSelecao.Reset();
        cronometroSelecao.Start();
        for (int i = 0; i < (vet.Length - 1); i++)
        {
            int menor = i;
            for (int j = (i + 1); j < vet.Length; j++)
            {
                contadorComparacoesChaves++;
                if (vet[i].GetMatricula() < vet[j].GetMatricula())
                {
                    menor = j;
                    contadorMovimentacoesRegistros++;
                }
            }
            Estudante temporario = vet[menor];
            vet[menor] = vet[i];
            vet[i] = temporario;
        }
        cronometroSelecao.Stop();
        TimeSpan time1 = cronometroSelecao.Elapsed;
        resultadosSelecao[0, 0] += contadorComparacoesChaves++; ;
        resultadosSelecao[1, 0] += contadorMovimentacoesRegistros;
        resultadosSelecao[2, 0] += time1.Milliseconds;
        cronometroSelecao.Reset();

        //Ordenando VETOR já ordenado
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroSelecao.Start();
        for (int i = 0; i < (vet.Length - 1); i++)
        {
            int menor = i;
            for (int j = (i + 1); j < vet.Length; j++)
            {
                contadorComparacoesChaves++;
                if (vet[i].GetMatricula() < vet[j].GetMatricula())
                {
                    menor = j;
                    contadorMovimentacoesRegistros++;
                }
            }
            Estudante temporario = vet[menor];
            vet[menor] = vet[i];
            vet[i] = temporario;
        }
        cronometroSelecao.Stop();
        TimeSpan time2 = cronometroSelecao.Elapsed;
        resultadosSelecao[0, 1] += contadorComparacoesChaves++; ;
        resultadosSelecao[1, 1] += contadorMovimentacoesRegistros;
        resultadosSelecao[2, 1] += time2.Milliseconds;
        cronometroSelecao.Reset();

        //Ordenando VETOR ordenado ao contrário
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroSelecao.Start();
        for (int i = 0; i < (vet.Length - 1); i++)
        {
            int menor = i;
            for (int j = (i + 1); j < vet.Length; j++)
            {
                contadorComparacoesChaves++;
                if (vet[i].GetMatricula() > vet[j].GetMatricula())
                {
                    menor = j;
                    contadorMovimentacoesRegistros++;
                }
            }
            Estudante temporario = vet[menor];
            vet[menor] = vet[i];
            vet[i] = temporario;
        }
        cronometroSelecao.Stop();
        TimeSpan time3 = cronometroSelecao.Elapsed;
        resultadosSelecao[0, 2] += contadorComparacoesChaves++; ;
        resultadosSelecao[1, 2] += contadorMovimentacoesRegistros;
        resultadosSelecao[2, 2] += time3.Milliseconds;
    }
    //Algoritmo Bolha
    static void VerificarDesempenhoBolha(Estudante[] vet, double[,] resultadosBolha)
    {
        //Ordenando VETOR aleatório
        Stopwatch cronometroBolha = new Stopwatch();
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        cronometroBolha.Reset();
        cronometroBolha.Start();
        Estudante temp1;
        for (int i = 0; i < (vet.Length - 1); i++)
        {
            for (int j = vet.Length - 1; j > i; j--)
            {
                contadorComparacoesChaves++;
                if (vet[j].GetMatricula() < vet[j - 1].GetMatricula())
                {
                    temp1 = vet[j];
                    vet[j] = vet[j - 1];
                    vet[j - 1] = temp1;
                    contadorMovimentacoesRegistros++;
                }
            }
        }
        cronometroBolha.Stop();
        TimeSpan time1 = cronometroBolha.Elapsed;
        resultadosBolha[0, 0] += contadorComparacoesChaves;
        resultadosBolha[1, 0] += contadorMovimentacoesRegistros;
        resultadosBolha[2, 0] += time1.Milliseconds;
        cronometroBolha.Reset();

        //Ordenando VETOR já ordenado
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroBolha.Start();
        Estudante temp2;
        for (int i = 0; i < (vet.Length - 1); i++)
        {
            for (int j = vet.Length - 1; j > i; j--)
            {
                contadorComparacoesChaves++;
                if (vet[j].GetMatricula() < vet[j - 1].GetMatricula())
                {
                    temp2 = vet[j];
                    vet[j] = vet[j - 1];
                    vet[j - 1] = temp2;
                    contadorMovimentacoesRegistros++;
                }
            }
        }
        cronometroBolha.Stop();
        TimeSpan time2 = cronometroBolha.Elapsed;
        resultadosBolha[0, 1] += contadorComparacoesChaves;
        resultadosBolha[1, 1] += contadorMovimentacoesRegistros;
        resultadosBolha[2, 1] += time2.Milliseconds;
        cronometroBolha.Reset();

        //Ordenando VETOR ordenado ao contrário 
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroBolha.Start();
        Estudante temp3;
        for (int i = 0; i < (vet.Length - 1); i++)
        {
            for (int j = vet.Length - 1; j > i; j--)
            {
                contadorComparacoesChaves++;
                if (vet[j].GetMatricula() > vet[j - 1].GetMatricula())
                {
                    temp3 = vet[j];
                    vet[j] = vet[j - 1];
                    vet[j - 1] = temp3;
                    contadorMovimentacoesRegistros++;
                }
            }
        }
        cronometroBolha.Stop();
        TimeSpan time3 = cronometroBolha.Elapsed;
        resultadosBolha[0, 2] += contadorComparacoesChaves;
        resultadosBolha[1, 2] += contadorMovimentacoesRegistros;
        resultadosBolha[2, 2] += time3.Milliseconds;
    }
    //Algoritmo Inserção
    static void VerificarDesempenhoInsercao(Estudante[] vet, double[,] resultadosInsercao)
    {
        //Ordenando VETOR aleatório
        Stopwatch cronometroInsercao = new Stopwatch();
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        cronometroInsercao.Reset();
        cronometroInsercao.Start();
        for (int i = 1; i < vet.Length; i++)
        {
            Estudante tmp = vet[i];
            int j = i - 1;
            contadorComparacoesChaves++; ;
            while ((j >= 0) && (vet[j].GetMatricula() > tmp.GetMatricula()))
            {
                contadorMovimentacoesRegistros++;
                vet[j + 1] = vet[j];
                j--;
            }
            vet[j + 1] = tmp;
        }
        cronometroInsercao.Stop();
        TimeSpan time1 = cronometroInsercao.Elapsed;
        resultadosInsercao[0, 0] += contadorComparacoesChaves;
        resultadosInsercao[1, 0] += contadorMovimentacoesRegistros;
        resultadosInsercao[2, 0] += time1.Milliseconds;
        cronometroInsercao.Reset();

        //Ordenando VETOR já ordenado
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroInsercao.Start();
        for (int i = 1; i < vet.Length; i++)
        {
            Estudante tmp = vet[i];
            int j = i - 1;
            contadorComparacoesChaves++; ;
            while ((j >= 0) && (vet[j].GetMatricula() > tmp.GetMatricula()))
            {
                contadorMovimentacoesRegistros++;
                vet[j + 1] = vet[j];
                j--;
            }
            vet[j + 1] = tmp;
        }
        cronometroInsercao.Stop();
        TimeSpan time2 = cronometroInsercao.Elapsed;
        resultadosInsercao[0, 1] += contadorComparacoesChaves;
        resultadosInsercao[1, 1] += contadorMovimentacoesRegistros;
        resultadosInsercao[2, 1] += time2.Milliseconds;
        cronometroInsercao.Reset();

        //Ordenando VETOR ordenado ao contrário
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroInsercao.Start();

        for (int i = 1; i < vet.Length; i++)
        {
            Estudante tmp = vet[i];
            int j = i - 1;
            contadorComparacoesChaves++;
            while ((j >= 0) && (vet[j].GetMatricula() < tmp.GetMatricula()))
            {
                contadorMovimentacoesRegistros++;
                vet[j + 1] = vet[j];
                j--;
            }
            vet[j + 1] = tmp;
        }
        cronometroInsercao.Stop();
        TimeSpan time3 = cronometroInsercao.Elapsed;
        resultadosInsercao[0, 2] += contadorComparacoesChaves;
        resultadosInsercao[1, 2] += contadorMovimentacoesRegistros;
        resultadosInsercao[2, 2] += time3.Milliseconds;
    }
    static string GerarString()
    {
        char[] alfabeto = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        char[] palavra = new char[8];
        for (int i = 0; i < palavra.Length; i++)
        {
            int j = numerosAleatorios.Next(0, 25);
            palavra[i] = alfabeto[j];
        }
        string nome = new string(palavra);
        return nome;
    }
    //Escrevendo no arquivo as médias dos resultados
    static void Escritor(double[,] resultados, string titulo, string tamanho)
    {
        escritorArquivo.WriteLine($"{titulo}\nMédias de 10 execuções tamanho [{tamanho}] ALEATÓRIO :\nMédia número de comparação de chaves: {resultados[0, 0] / 10}\nMédia número de movimentações: {resultados[1, 0] / 10}\nMédia tempo médio: {resultados[2, 0] / 10} Milessegundo\n\nMédias de 10 execuções tamanho [{tamanho}] ORDENADO :\nMédia número de comparação de chaves: {resultados[0, 1] / 10}\nMédia número de movimentações: {resultados[1, 1] / 10}\nMédia tempo médio: {resultados[2, 1] / 10} Milessegundo\n\nMédias de 10 execuções tamanho [{tamanho}] ORDENADO AO CONTRÁRIO :\nMédia número de comparação de chaves: {resultados[0, 2] / 10}\nMédia número de movimentações: {resultados[1, 2] / 10}\nMédia tempo médio: {resultados[2, 2] / 10} Milessegundo\n\n");
        escritorArquivo.WriteLine("*****************************************************");
    }
    //Exibindo no console os dados do vetor de classe ordenado.
    static void MostrarDadosEstudante(Estudante[] estudante, string tamanho)
    {
        Console.WriteLine($"\n****DADOS DO VETOR DE TAMANHO {tamanho}****\n\n");
        for (int i = 0; i < estudante.Length; i++)
        {
            Console.WriteLine($"Matrícula: {estudante[i].GetMatricula()}\nNome: {estudante[i].GetNome()}\nCurso: {estudante[i].GetCurso()}\nCoeficiente de rendimento: {estudante[i].GetCoefiente()}\nPeríodo: {estudante[i].GetPeriodo()}\n\n");
        }
    }
}