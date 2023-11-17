using System.Diagnostics;
using System.Text;
class Program
{
    static StreamWriter escritorArquivo = new StreamWriter("Registros.txt", true, Encoding.UTF8);
    static void Main(string[] args)
    {

        Console.ForegroundColor = ConsoleColor.White;
        Stopwatch cronometroExecucaoPrograma = new Stopwatch();
        Random numerosAleatorios = new Random();
        double[,] resultadosSelecao1k = new double[3, 4];
        double[,] resultadosSelecao10k = new double[3, 4];
        double[,] resultadosSelecao20k = new double[3, 4];
        double[,] resultadosSelecao50k = new double[3, 4];
        double[,] resultadosBolha1k = new double[3, 4];
        double[,] resultadosBolha10k = new double[3, 4];
        double[,] resultadosBolha20k = new double[3, 4];
        double[,] resultadosBolha50k = new double[3, 4];
        double[,] resultadosInsercao1k = new double[3, 4];
        double[,] resultadosInsercao10k = new double[3, 4];
        double[,] resultadosInsercao20k = new double[3, 4];
        double[,] resultadosInsercao50k = new double[3, 4];
        int[] vetor1 = new int[1000];
        int[] vetor2 = new int[10000];
        int[] vetor3 = new int[20000];
        int[] vetor4 = new int[50000];
        int[] vetor1copy = new int[1000];
        int[] vetor2copy = new int[10000];
        int[] vetor3copy = new int[20000];
        int[] vetor4copy = new int[50000];

        //Gerador de números aleatórios
        for (int i = 0; i < vetor1.Length; i++)
        {
            vetor1[i] = numerosAleatorios.Next(0, 999);
        }
        for (int i = 0; i < vetor2.Length; i++)
        {
            vetor2[i] = numerosAleatorios.Next(0, 1000);
        }
        for (int i = 0; i < vetor3.Length; i++)
        {
            vetor3[i] = numerosAleatorios.Next(0, 1000);
        }
        for (int i = 0; i < vetor4.Length; i++)
        {
            vetor4[i] = numerosAleatorios.Next(0, 1000);
        }
        //Copiando valores para outro vetor
        Array.Copy(vetor1, vetor1copy, vetor1.Length);
        Array.Copy(vetor2, vetor2copy, vetor2.Length);
        Array.Copy(vetor3, vetor3copy, vetor3.Length);
        Array.Copy(vetor4, vetor4copy, vetor4.Length);
        int opcao, escolherVetor = 0;
        try
        {
            Console.WriteLine("\n\nVocê deseja imprimir o antes e depois dos vetores? (ao final)");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("(Essa ação pode não ser executada como esperado em alguns dispositivos devido ao grande tamanho dos vetores)");
            Console.ResetColor();
            Console.WriteLine("\n1)Sim\n2)Não");
            opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                Console.WriteLine("\nQual vetor deseja imprimir?\n\n1) Vetor 1\n2) Vetor 2\n3) Vetor 3\n4) Vetor 4");
                escolherVetor = int.Parse(Console.ReadLine());
                if (escolherVetor < 1 || escolherVetor > 4)
                {
                    Console.WriteLine("****DIGITE UMA OPÇÃO VÁLIDA****\n");
                    escolherVetor = int.Parse(Console.ReadLine());
                }
            }
            else if (opcao != 1 && opcao != 2)
            {
                Console.WriteLine("****DIGITE UMA OPÇÃO VÁLIDA****\n");
                opcao = int.Parse(Console.ReadLine());
            }
            if (opcao == 1 || opcao == 2)
            {
                //Iniciando cronômetro execução do programa
                cronometroExecucaoPrograma.Start();

                //Laço para realizar cada teste 10 vezes.
                for (int j = 0; j < 10; j++)
                {
                    VerificarDesempenhoSelecao(vetor1copy, resultadosSelecao1k);
                    VerificarDesempenhoSelecao(vetor2copy, resultadosSelecao10k);
                    VerificarDesempenhoSelecao(vetor3copy, resultadosSelecao20k);
                    VerificarDesempenhoSelecao(vetor4copy, resultadosSelecao50k);
                }
                for (int j = 0; j < 10; j++)
                {
                    VerificarDesempenhoBolha(vetor1copy, resultadosBolha1k);
                    VerificarDesempenhoBolha(vetor2copy, resultadosBolha10k);
                    VerificarDesempenhoBolha(vetor3copy, resultadosBolha20k);
                    VerificarDesempenhoBolha(vetor4copy, resultadosBolha50k);
                }
                for (int j = 0; j < 10; j++)
                {
                    VerificarDesempenhoInsercao(vetor1copy, resultadosInsercao1k);
                    VerificarDesempenhoInsercao(vetor2copy, resultadosInsercao10k);
                    VerificarDesempenhoInsercao(vetor3copy, resultadosInsercao20k);
                    VerificarDesempenhoInsercao(vetor4copy, resultadosInsercao50k);
                }
                cronometroExecucaoPrograma.Stop();
                TimeSpan time = cronometroExecucaoPrograma.Elapsed;
                string hora = String.Format("{0:00}", time.Hours);
                string minuto = String.Format("{0:00}", time.Minutes);
                string segundo = String.Format("{0:00}", time.TotalSeconds);

                //Escrever no arquivo e no console as médias de resultados
                Escritor(resultadosSelecao1k, "\nALGORITMO SELEÇÃO\n\n", "1.000");
                Escritor(resultadosSelecao10k, "\n\nALGORITMO SELEÇÃO\n\n", "10.000");
                Escritor(resultadosSelecao10k, "\n\nALGORITMO SELEÇÃO\n\n", "20.000");
                Escritor(resultadosSelecao20k, "\n\nALGORITMO SELEÇÃO\n\n", "50.000");
                Escritor(resultadosBolha1k, "\nALGORITMO BOLHA\n\n", "1.000");
                Escritor(resultadosBolha10k, "\nALGORITMO BOLHA\n\n", "10.000");
                Escritor(resultadosBolha10k, "\nALGORITMO BOLHA\n\n", "20.000");
                Escritor(resultadosBolha20k, "\nALGORITMO BOLHA\n\n", "50.000");
                Escritor(resultadosInsercao1k, "\nALGORITMO INSERÇÃO\n\n", "1.000");
                Escritor(resultadosInsercao10k, "\nALGORITMO INSERÇÃO\n\n", "10.000");
                Escritor(resultadosInsercao10k, "\nALGORITMO INSERÇÃO\n\n", "20.000");
                Escritor(resultadosInsercao20k, "\nALGORITMO INSERÇÃO\n\n", "50.000");
                escritorArquivo.WriteLine($"\nTEMPO DE EXEUÇÃO DO PROGRAMA: {hora} Hora, {minuto} Minutos, {segundo} Segundos.");
                Console.WriteLine("PROGRAMA FINALIZDO!");
                escritorArquivo.Close();

                //Imprimindo vetores
                if (escolherVetor == 1)
                { ImprimirVetores(vetor1, vetor1copy); }
                if (escolherVetor == 2)
                { ImprimirVetores(vetor2, vetor2copy); }
                if (escolherVetor == 3)
                { ImprimirVetores(vetor3, vetor3copy); }
                if (escolherVetor == 4)
                { ImprimirVetores(vetor4, vetor4copy); }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Você digitou um caractere inválido, o menu funciona apenas com números");
        }
    }
    //Algoritmo SELEÇÃO
    static void VerificarDesempenhoSelecao(int[] vet, double[,] resultadosSelecao)
    {
        //Ordenando VETOR aleatório
        Stopwatch cronometroSelecao = new Stopwatch();
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        cronometroSelecao.Reset();
        cronometroSelecao.Start();
        Selecao(vet);
        void Selecao(int[] vet)
        {
            for (int i = 0; i < (vet.Length - 1); i++)
            {
                int menor = i;
                for (int j = (i + 1); j < vet.Length; j++)
                {
                    contadorComparacoesChaves++;
                    if (vet[menor] < vet[j])
                    {
                        menor = j;
                        contadorMovimentacoesRegistros++;
                    }
                }
                int temporario = vet[menor];
                vet[menor] = vet[i];
                vet[i] = temporario;
            }
        }
        cronometroSelecao.Stop();
        TimeSpan time1 = cronometroSelecao.Elapsed;
        resultadosSelecao[0, 0] += contadorComparacoesChaves;
        resultadosSelecao[1, 0] += contadorMovimentacoesRegistros;
        resultadosSelecao[2, 0] += time1.Milliseconds;
        cronometroSelecao.Reset();

        //Ordenando VETOR já ordenado
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroSelecao.Start();
        SelecaoJaOrdenado(vet);
        void SelecaoJaOrdenado(int[] vet)
        {
            for (int i = 0; i < (vet.Length - 1); i++)
            {
                int menor = i;
                for (int j = (i + 1); j < vet.Length; j++)
                {
                    contadorComparacoesChaves++;
                    if (vet[menor] < vet[j])
                    {
                        menor = j;
                        contadorMovimentacoesRegistros++;
                    }
                }
                int temporario = vet[menor];
                vet[menor] = vet[i];
                vet[i] = temporario;
            }
        }
        cronometroSelecao.Stop();
        TimeSpan time2 = cronometroSelecao.Elapsed;
        resultadosSelecao[0, 1] += contadorComparacoesChaves;
        resultadosSelecao[1, 1] += contadorMovimentacoesRegistros;
        resultadosSelecao[2, 1] += time2.Milliseconds;
        cronometroSelecao.Reset();

        //Ordenando VETOR ordenado ao contrário
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroSelecao.Start();
        SelecaoInversamenteOrdenado(vet);
        void SelecaoInversamenteOrdenado(int[] vet)
        {
            for (int i = 0; i < (vet.Length - 1); i++)
            {
                int menor = i;
                for (int j = (i + 1); j < vet.Length; j++)
                {
                    contadorComparacoesChaves++;
                    if (vet[menor] > vet[j])
                    {
                        menor = j;
                        contadorMovimentacoesRegistros++;
                    }
                }
                int temporario = vet[menor];
                vet[menor] = vet[i];
                vet[i] = temporario;
            }
        }
        cronometroSelecao.Stop();
        TimeSpan time3 = cronometroSelecao.Elapsed;
        resultadosSelecao[0, 2] += contadorComparacoesChaves;
        resultadosSelecao[1, 2] += contadorMovimentacoesRegistros;
        resultadosSelecao[2, 2] += time3.Milliseconds;
    }
    //Algoritmo BOLHA
    static void VerificarDesempenhoBolha(int[] vet, double[,] resultadosBolha)
    {
        //Ordenando VETOR aleatório
        Stopwatch cronometroBolha = new Stopwatch();
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        cronometroBolha.Reset();
        cronometroBolha.Start();
        Bolha(vet);
        void Bolha(int[] vet)
        {
            int temp;
            for (int i = 0; i < (vet.Length - 1); i++)
            {
                for (int j = vet.Length - 1; j > i; j--)
                {
                    contadorComparacoesChaves++;
                    if (vet[j] < vet[j - 1])
                    {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                        contadorMovimentacoesRegistros++;
                    }
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
        BolhaJaOrdenado(vet);
        void BolhaJaOrdenado(int[] vet)
        {
            int temp1;
            for (int i = 0; i < (vet.Length - 1); i++)
            {
                for (int j = vet.Length - 1; j > i; j--)
                {
                    contadorComparacoesChaves++;
                    if (vet[j] < vet[j - 1])
                    {
                        temp1 = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp1;
                        contadorMovimentacoesRegistros++;
                    }
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
        BolhaInversamenteOrdenado(vet);
        void BolhaInversamenteOrdenado(int[] vet)
        {
            int temp3;
            for (int i = 0; i < (vet.Length - 1); i++)
            {
                for (int j = vet.Length - 1; j > i; j--)
                {
                    contadorComparacoesChaves++;
                    if (vet[j] > vet[j - 1])
                    {
                        temp3 = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp3;
                        contadorMovimentacoesRegistros++;
                    }
                }
            }
        }
        cronometroBolha.Stop();
        TimeSpan time3 = cronometroBolha.Elapsed;
        resultadosBolha[0, 2] += contadorComparacoesChaves;
        resultadosBolha[1, 2] += contadorMovimentacoesRegistros;
        resultadosBolha[2, 2] += time3.Milliseconds;
    }
    //Algoritmo INSERCÃO
    static void VerificarDesempenhoInsercao(int[] vet, double[,] resultadosInsercao)
    {
        //Ordenando VETOR aleatório
        Stopwatch cronometroInsercao = new Stopwatch();
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        cronometroInsercao.Reset();
        cronometroInsercao.Start();
        Insercao(vet);
        void Insercao(int[] vet)
        {
            for (int i = 1; i < vet.Length; i++)
            {
                int tmp = vet[i];
                int j = i - 1;
                contadorComparacoesChaves++;
                while ((j >= 0) && (vet[j] > tmp))
                {
                    contadorMovimentacoesRegistros++;
                    vet[j + 1] = vet[j];
                    j--;
                }
                vet[j + 1] = tmp;
            }
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
        InsercaoJaOrdenado(vet);
        void InsercaoJaOrdenado(int[] vet)
        {
            for (int i = 1; i < vet.Length; i++)
            {
                int tmp = vet[i];
                int j = i - 1;
                contadorComparacoesChaves++; ;
                while ((j >= 0) && (vet[j] > tmp))
                {
                    contadorMovimentacoesRegistros++;
                    vet[j + 1] = vet[j];
                    j--;
                }
                vet[j + 1] = tmp;
            }
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
        InsercaoInversamenteOrdenado(vet);
        void InsercaoInversamenteOrdenado(int[] vet)
        {
            for (int i = 1; i < vet.Length; i++)
            {
                int tmp = vet[i];
                int j = i - 1;
                contadorComparacoesChaves++; ;
                while ((j >= 0) && (vet[j] < tmp))
                {
                    contadorMovimentacoesRegistros++;
                    vet[j + 1] = vet[j];
                    j--;
                }
                vet[j + 1] = tmp;
            }
        }
        cronometroInsercao.Stop();
        TimeSpan time3 = cronometroInsercao.Elapsed;
        resultadosInsercao[0, 2] += contadorComparacoesChaves;
        resultadosInsercao[1, 2] += contadorMovimentacoesRegistros;
        resultadosInsercao[2, 2] += time3.Milliseconds;
    }
    //Escrevendo no arquivo as médias dos resultados
    static void Escritor(double[,] resultados, string titulo, string tamanho)
    {
        escritorArquivo.WriteLine($"{titulo}\nMédias de 10 execuções tamanho [{tamanho}] ALEATÓRIO :\nMédia número de comparação de chaves: {resultados[0, 0] / 10}\nMédia número de movimentações: {resultados[1, 0] / 10}\nMédia tempo médio: {resultados[2, 0] / 10} Milessegundo\n\nMédias de 10 execuções tamanho [{tamanho}] ORDENADO :\nMédia número de comparação de chaves: {resultados[0, 1] / 10}\nMédia número de movimentações: {resultados[1, 1] / 10}\nMédia tempo médio: {resultados[2, 1] / 10} Milessegundo\n\nMédias de 10 execuções tamanho [{tamanho}] ORDENADO AO CONTRÁRIO :\nMédia número de comparação de chaves: {resultados[0, 2] / 10}\nMédia número de movimentações: {resultados[1, 2] / 10}\nMédia tempo médio: {resultados[2, 2] / 10} Milessegundo\n\n");
        escritorArquivo.WriteLine("*****************************************************");

        //Escrevendo no console as médias dos resultados
        Console.WriteLine($"******************{titulo}******************\nMédias de 10 execuções tamanho [{tamanho}] ALEATÓRIO :\nMédia número de comparação de chaves: {resultados[0, 0] / 10}\nMédia número de movimentações: {resultados[1, 0] / 10}\nMédia tempo médio: {resultados[2, 0] / 10} Milessegundo\n\nMédias de 10 execuções tamanho [{tamanho}] ORDENADO:\nMédia número de comparação de chaves: {resultados[0, 1] / 10}\nMédia número de movimentações: {resultados[1, 1] / 10}\nMédia tempo médio: {resultados[2, 1] / 10} Milessegundo\n\nMédias de 10 execuções tamanho [{tamanho}] ORDENADO AO CONTRÁRIO:\nMédia número de comparação de chaves: {resultados[0, 2] / 10}\nMédia número de movimentações: {resultados[1, 2] / 10}\nMédia tempo médio: {resultados[2, 2] / 10} Milessegundo\n\n");

    }
    static void ImprimirVetores(int[] vet, int[] vetcopy)
    {
        Console.WriteLine("\n****VETORES ANTES DA EXECUÇÃO****\n");
        ImprimirVetor(vet);
        Console.WriteLine("\n****VETORES DEPOIS DA EXECUÇÃO****\n");
        ImprimirVetor(vetcopy);
    }
    static void ImprimirVetor(int[] vet)
    {
        for (int i = 0; i < vet.Length; i++)
        {
            Console.Write(vet[i] + " ");
        }
        Console.WriteLine("");
    }
}