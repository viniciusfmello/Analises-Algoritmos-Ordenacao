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
        double[,] resultadosShellSort500 = new double[3, 4];
        double[,] resultadosShellSort1k = new double[3, 4];
        double[,] resultadosShellSort5k = new double[3, 4];
        double[,] resultadosShellSort15k = new double[3, 4];
        double[,] resultadosMergeSort500 = new double[3, 4];
        double[,] resultadosMergeSort1k = new double[3, 4];
        double[,] resultadosMergeSort5k = new double[3, 4];
        double[,] resultadosMergeSort15k = new double[3, 4];
        double[,] resultadosQuickSort500 = new double[3, 4];
        double[,] resultadosQuickSort1k = new double[3, 4];
        double[,] resultadosQuickSort5k = new double[3, 4];
        double[,] resultadosQuickSort15k = new double[3, 4];
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
            VerificarDesempenhoShellSort(estudante.vetor1copy, resultadosShellSort500);
            VerificarDesempenhoShellSort(estudante.vetor2copy, resultadosShellSort1k);
            VerificarDesempenhoShellSort(estudante.vetor3copy, resultadosShellSort5k);
            VerificarDesempenhoShellSort(estudante.vetor4copy, resultadosShellSort15k);
        }
        for (int j = 0; j < 10; j++)
        {
            VerificarDesempenhoMergeSort(estudante.vetor1copy, resultadosMergeSort500);
            VerificarDesempenhoMergeSort(estudante.vetor2copy, resultadosMergeSort1k);
            VerificarDesempenhoMergeSort(estudante.vetor3copy, resultadosMergeSort5k);
            VerificarDesempenhoMergeSort(estudante.vetor4copy, resultadosMergeSort15k);
        }
        for (int j = 0; j < 10; j++)
        {
            VerificarDesempenhoQuickSort(estudante.vetor1copy, resultadosQuickSort500);
            VerificarDesempenhoQuickSort(estudante.vetor2copy, resultadosQuickSort1k);
            VerificarDesempenhoQuickSort(estudante.vetor3copy, resultadosQuickSort5k);
            VerificarDesempenhoQuickSort(estudante.vetor4copy, resultadosQuickSort15k);
        }
        cronometroExecucaoPrograma.Stop();
        TimeSpan time = cronometroExecucaoPrograma.Elapsed;
        string hora = String.Format("{0:00}", time.Hours);
        string minuto = String.Format("{0:00}", time.Minutes);
        string segundo = String.Format("{0:00}", time.TotalSeconds);
        //Escrever no arquivo as médias de resultados
        Escritor(resultadosShellSort500, "\nALGORITMO SHELL SORT\n\n", "1000");
        Escritor(resultadosShellSort1k, "\n\nALGORITMO SHELL SORT\n\n", "1.000");
        Escritor(resultadosShellSort5k, "\n\nALGORITMO SHELL SORT\n\n", "5.000");
        Escritor(resultadosShellSort15k, "\n\nALGORITMO SHELL SORT\n\n", "15.000");
        Escritor(resultadosMergeSort1k, "\n\nALGORITMO MERGE SORT\n\n", "1000");
        Escritor(resultadosMergeSort1k, "\n\nALGORITMO MERGE SORT\n\n", "1.000");
        Escritor(resultadosMergeSort5k, "\n\nALGORITMO MERGE SORT\n\n", "5.000");
        Escritor(resultadosMergeSort15k, "\n\nALGORITMO MERGE SORT\n\n", "10.000");
        Escritor(resultadosQuickSort500, "\n\nALGORITMO QUICK SORT\n\n", "1000");
        Escritor(resultadosQuickSort1k, "\n\nALGORITMO QUICK SORT\n\n", "1.000");
        Escritor(resultadosQuickSort5k, "\n\nALGORITMO QUICK SORT\n\n", "5.000");
        Escritor(resultadosQuickSort15k, "\n\nALGORITMO QUICK SORT\n\n", "15.000");
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
    //Algoritmo Shell Sort
    static void VerificarDesempenhoShellSort(Estudante[] vet, double[,] resultadosShellSort)
    {
        //Ordenando VETOR aleatório
        Stopwatch cronometroShellSort = new Stopwatch();
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        void QuickSortPorCor(int cor, int h)
        {
            for (int i = (h + cor); i < vet.Length; i += h)
            {
                Estudante tmp = vet[i];
                int j = i - h;
                contadorComparacoesChaves++;
                while ((j >= 0) && (vet[j].GetMatricula() > tmp.GetMatricula()))
                {
                    vet[j + h] = vet[j];
                    j -= h;
                    contadorMovimentacoesRegistros++;
                }
                vet[j + h] = tmp;
                contadorMovimentacoesRegistros++;
            }
        }
        void QuickSortPorCorInversamenteOrdenado(int cor, int h)
        {
            for (int i = (h + cor); i < vet.Length; i += h)
            {
                Estudante tmp = vet[i];
                int j = i - h;
                contadorComparacoesChaves++;
                while ((j >= 0) && (vet[j].GetMatricula() < tmp.GetMatricula()))
                {
                    vet[j + h] = vet[j];
                    j -= h;
                    contadorMovimentacoesRegistros++;
                }
                vet[j + h] = tmp;
                contadorMovimentacoesRegistros++;
            }
        }
        cronometroShellSort.Reset();
        int h = 1;
        cronometroShellSort.Start();
        do { h = (h * 3) + 1; } while (h < vet.Length);
        do
        {
            h /= 3;
            for (int cor = 0; cor < h; cor++)
            {
                QuickSortPorCor(cor, h);
            }
        } while (h != 1);

        cronometroShellSort.Stop();
        TimeSpan time1 = cronometroShellSort.Elapsed;
        resultadosShellSort[0, 0] += contadorComparacoesChaves++; ;
        resultadosShellSort[1, 0] += contadorMovimentacoesRegistros;
        resultadosShellSort[2, 0] += time1.Milliseconds;
        cronometroShellSort.Reset();

        //Ordenando VETOR já ordenado
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        h = 1;

        cronometroShellSort.Start();
        do { h = (h * 3) + 1; } while (h < vet.Length);
        do
        {
            h /= 3;
            for (int cor = 0; cor < h; cor++)
            {
                QuickSortPorCor(cor, h);
            }
        } while (h != 1);
        cronometroShellSort.Stop();

        TimeSpan time2 = cronometroShellSort.Elapsed;
        resultadosShellSort[0, 1] += contadorComparacoesChaves++; ;
        resultadosShellSort[1, 1] += contadorMovimentacoesRegistros;
        resultadosShellSort[2, 1] += time2.Milliseconds;
        cronometroShellSort.Reset();

        //Ordenando VETOR ordenado ao contrário
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        h = 1;
        cronometroShellSort.Start();
        do { h = (h * 3) + 1; } while (h < vet.Length);
        do
        {
            h /= 3;
            for (int cor = 0; cor < h; cor++)
            {
                QuickSortPorCorInversamenteOrdenado(cor, h);
            }
        } while (h != 1);

        cronometroShellSort.Stop();
        TimeSpan time3 = cronometroShellSort.Elapsed;
        resultadosShellSort[0, 2] += contadorComparacoesChaves++; ;
        resultadosShellSort[1, 2] += contadorMovimentacoesRegistros;
        resultadosShellSort[2, 2] += time3.Milliseconds;
    }

    //Algoritmo Merge Sort
    static void VerificarDesempenhoMergeSort(Estudante[] vet, double[,] resultadosMergeSort)
    {
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        int esq = 0, dir = vet.Length - 1;
        void Intercala(Estudante[] vet, int esq, int meio, int dir)
        {
            int n1 = meio - esq + 1;
            int n2 = dir - meio;
            Estudante[] vet_esq = new Estudante[n1];
            Estudante[] vet_dir = new Estudante[n2];
            for (int i = 0; i < n1; i++)
            {
                vet_esq[i] = vet[esq + i];
            }
            for (int j = 0; j < n2; j++)
            {
                vet_dir[j] = vet[meio + 1 + j];
            }
            int cont1 = 0, cont2 = 0;
            int k = esq;
            contadorComparacoesChaves++;
            while (cont1 < n1 && cont2 < n2)
            {
                contadorComparacoesChaves++;
                if (vet_esq[cont1].GetMatricula() <= vet_dir[cont2].GetMatricula())
                {
                    vet[k] = vet_esq[cont1];
                    contadorMovimentacoesRegistros++;
                    cont1++;
                }
                else
                {
                    vet[k] = vet_dir[cont2];
                    contadorMovimentacoesRegistros++;
                    cont2++;
                }
                k++;
            }
            contadorComparacoesChaves++;
            while (cont1 < n1)
            {
                contadorMovimentacoesRegistros++;
                vet[k] = vet_esq[cont1];
                cont1++;
                k++;
            }
            contadorComparacoesChaves++;
            while (cont2 < n2)
            {
                contadorMovimentacoesRegistros++;
                vet[k] = vet_dir[cont2];
                cont2++;
                k++;
            }
        }
        void IntercalaInversamente(Estudante[] vet, int esq, int meio, int dir)
        {
            int n1 = meio - esq + 1;
            int n2 = dir - meio;
            Estudante[] vet_esq = new Estudante[n1];
            Estudante[] vet_dir = new Estudante[n2];
            for (int i = 0; i < n1; i++)
                vet_esq[i] = vet[esq + i];
            for (int j = 0; j < n2; j++)
                vet_dir[j] = vet[meio + 1 + j];
            int cont1 = 0, cont2 = 0;
            int k = esq;
            contadorComparacoesChaves++;
            while (cont1 < n1 && cont2 < n2)
            {
                contadorComparacoesChaves++;
                if (vet_esq[cont1].GetMatricula() >= vet_dir[cont2].GetMatricula())
                {
                    vet[k] = vet_esq[cont1];
                    contadorMovimentacoesRegistros++;
                    cont1++;
                }
                else
                {
                    vet[k] = vet_dir[cont2];
                    contadorMovimentacoesRegistros++;
                    cont2++;
                }
                k++;
            }
            contadorComparacoesChaves++;
            while (cont1 < n1)
            {
                contadorMovimentacoesRegistros++;
                vet[k] = vet_esq[cont1];
                cont1++;
                k++;
            }
            contadorComparacoesChaves++;
            while (cont2 < n2)
            {
                contadorMovimentacoesRegistros++;
                vet[k] = vet_dir[cont2];
                cont2++;
                k++;
            }
        }
        //Ordenando VETOR aleatório
        Stopwatch cronometroMergeSort = new Stopwatch();
        cronometroMergeSort.Reset();
        cronometroMergeSort.Start();
        MergeSort1(vet, esq, dir);
        void MergeSort1(Estudante[] vet, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                MergeSort1(vet, esq, meio);
                MergeSort1(vet, meio + 1, dir);
                Intercala(vet, esq, meio, dir);
            }
        }
        cronometroMergeSort.Stop();
        TimeSpan time1 = cronometroMergeSort.Elapsed;
        resultadosMergeSort[0, 0] += contadorComparacoesChaves;
        resultadosMergeSort[1, 0] += contadorMovimentacoesRegistros;
        resultadosMergeSort[2, 0] += time1.Milliseconds;
        cronometroMergeSort.Reset();

        //Ordenando VETOR já ordenado
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroMergeSort.Start();
        MergeSort2(vet, esq, dir);
        void MergeSort2(Estudante[] vet, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                MergeSort2(vet, esq, meio);
                MergeSort2(vet, meio + 1, dir);
                Intercala(vet, esq, meio, dir);
            }
        }
        cronometroMergeSort.Stop();

        TimeSpan time2 = cronometroMergeSort.Elapsed;
        resultadosMergeSort[0, 1] += contadorComparacoesChaves;
        resultadosMergeSort[1, 1] += contadorMovimentacoesRegistros;
        resultadosMergeSort[2, 1] += time2.Milliseconds;
        cronometroMergeSort.Reset();

        //Ordenando VETOR ordenado ao contrário 
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroMergeSort.Start();
        MergeSort3(vet, esq, dir);
        void MergeSort3(Estudante[] vet, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                MergeSort3(vet, esq, meio);
                MergeSort3(vet, meio + 1, dir);
                IntercalaInversamente(vet, esq, meio, dir);
            }
        }
        cronometroMergeSort.Stop(); ;
        TimeSpan time3 = cronometroMergeSort.Elapsed;
        resultadosMergeSort[0, 2] += contadorComparacoesChaves;
        resultadosMergeSort[1, 2] += contadorMovimentacoesRegistros;
        resultadosMergeSort[2, 2] += time3.Milliseconds;
    }
    //Algoritmo Quick Sort
    static void VerificarDesempenhoQuickSort(Estudante[] vet, double[,] resultadosQuickSort)
    {
       void Trocar(int i, int j)
        {
            Estudante temp = vet[i];
            vet[i] = vet[j];
            vet[j] = temp;
        }
        //Ordenando VETOR aleatório
        Stopwatch cronometroQuickSort = new Stopwatch();
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;

        cronometroQuickSort.Reset();
        cronometroQuickSort.Start();
        int esq = 0, dir = vet.Length - 1;
        Quicksort1(vet, esq, dir);
        void Quicksort1(Estudante[] vet, int esq, int dir)
        {
            int i = esq, j = dir, pivo = vet[(esq + dir) / 2].GetMatricula();
            while (i <= j)
            {
                contadorComparacoesChaves++;
                while (vet[i].GetMatricula() < pivo) { i++; }
                contadorComparacoesChaves++;
                while (vet[j].GetMatricula() > pivo) { j--; }
                contadorComparacoesChaves++;
                if (i <= j)
                {
                    Trocar(i, j); i++; j--;
                    contadorMovimentacoesRegistros++;
                }
            }
            contadorComparacoesChaves++;
            if (esq < j)
            { Quicksort1(vet, esq, j); }
            contadorComparacoesChaves++;
            if (i < dir)
            { Quicksort1(vet, i, dir); }
            cronometroQuickSort.Stop();
        }
        TimeSpan time1 = cronometroQuickSort.Elapsed;
        resultadosQuickSort[0, 0] += contadorComparacoesChaves;
        resultadosQuickSort[1, 0] += contadorMovimentacoesRegistros;
        resultadosQuickSort[2, 0] += time1.Milliseconds;
        cronometroQuickSort.Reset();

        //Ordenando VETOR já ordenado
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;
        cronometroQuickSort.Start();
        Quicksort2(vet, esq, dir);
        void Quicksort2(Estudante[] vet, int esq, int dir)
        {
            int i = esq, j = dir, pivo = vet[(esq + dir) / 2].GetMatricula();
            while (i <= j)
            {
                contadorComparacoesChaves++;
                while (vet[i].GetMatricula() < pivo) { i++; }
                contadorComparacoesChaves++;
                while (vet[j].GetMatricula() > pivo) { j--; }
                contadorComparacoesChaves++;
                if (i <= j)
                {
                    Trocar(i, j); i++; j--;
                    contadorMovimentacoesRegistros++;
                }
            }
            contadorComparacoesChaves++;
            if (esq < j)
            { Quicksort2(vet, esq, j); }
            contadorComparacoesChaves++;
            if (i < dir)
            { Quicksort2(vet, i, dir); }
        }
        cronometroQuickSort.Stop();
        TimeSpan time2 = cronometroQuickSort.Elapsed;
        resultadosQuickSort[0, 1] += contadorComparacoesChaves;
        resultadosQuickSort[1, 1] += contadorMovimentacoesRegistros;
        resultadosQuickSort[2, 1] += time2.Milliseconds;
        cronometroQuickSort.Reset();

        //Ordenando VETOR ordenado ao contrário
        contadorComparacoesChaves = 0;
        contadorMovimentacoesRegistros = 0;

        Quicksort3(vet, esq, dir);
        void Quicksort3(Estudante[] vet, int esq, int dir)
        {
            cronometroQuickSort.Start();
            int i = esq, j = dir, pivo = vet[(esq + dir) / 2].GetMatricula();
            while (i <= j)
            {
                contadorComparacoesChaves++;
                while (vet[i].GetMatricula() > pivo) { i++; }
                contadorComparacoesChaves++;
                while (vet[j].GetMatricula() < pivo) { j--; }
                contadorComparacoesChaves++;
                if (i <= j)
                {
                    Trocar(i, j); i++; j--;
                    contadorMovimentacoesRegistros++;
                }
            }
            contadorComparacoesChaves++;
            if (esq < j)
            { Quicksort3(vet, esq, j); }
            contadorComparacoesChaves++;
            if (i < dir)
            { Quicksort3(vet, i, dir); }

        }
        cronometroQuickSort.Stop();
        TimeSpan time3 = cronometroQuickSort.Elapsed;
        resultadosQuickSort[0, 2] += contadorComparacoesChaves;
        resultadosQuickSort[1, 2] += contadorMovimentacoesRegistros;
        resultadosQuickSort[2, 2] += time3.Milliseconds;
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