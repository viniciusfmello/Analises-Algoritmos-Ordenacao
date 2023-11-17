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
        double[,] resultadosShellSort1k = new double[3, 4];
        double[,] resultadosShellSort10k = new double[3, 4];
        double[,] resultadosShellSort100k = new double[3, 4];
        double[,] resultadosShellSort200k = new double[3, 4];
        double[,] resultadosMergeSort1k = new double[3, 4];
        double[,] resultadosMergeSort10k = new double[3, 4];
        double[,] resultadosMergeSort100k = new double[3, 4];
        double[,] resultadosMergeSort200k = new double[3, 4];
        double[,] resultadosQuickSort1k = new double[3, 4];
        double[,] resultadosQuickSort10k = new double[3, 4];
        double[,] resultadosQuickSort100k = new double[3, 4];
        double[,] resultadosQuickSort200k = new double[3, 4];
        int[] vetor1 = new int[1000];
        int[] vetor2 = new int[10000];
        int[] vetor3 = new int[100000];
        int[] vetor4 = new int[200000];
        int[] vetor1copy = new int[1000];
        int[] vetor2copy = new int[10000];
        int[] vetor3copy = new int[100000];
        int[] vetor4copy = new int[200000];
        int escolherVetor = 0;

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
        int opcao;
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
                    VerificarDesempenhoShellSort(vetor1copy, resultadosShellSort1k);
                    VerificarDesempenhoShellSort(vetor2copy, resultadosShellSort10k);
                    VerificarDesempenhoShellSort(vetor3copy, resultadosShellSort100k);
                    VerificarDesempenhoShellSort(vetor4copy, resultadosShellSort200k);
                }

                for (int j = 0; j < 10; j++)
                {

                    VerificarDesempenhoMergeSort(vetor1copy, resultadosMergeSort1k);
                    VerificarDesempenhoMergeSort(vetor2copy, resultadosMergeSort10k);
                    VerificarDesempenhoMergeSort(vetor3copy, resultadosMergeSort100k);
                    VerificarDesempenhoMergeSort(vetor4copy, resultadosMergeSort200k);
                }
                for (int j = 0; j < 10; j++)
                {
                    VerificarDesempenhoQuickSort(vetor1copy, resultadosQuickSort1k);
                    VerificarDesempenhoQuickSort(vetor2copy, resultadosQuickSort10k);
                    VerificarDesempenhoQuickSort(vetor3copy, resultadosQuickSort100k);
                    VerificarDesempenhoQuickSort(vetor4copy, resultadosQuickSort200k);
                }
                cronometroExecucaoPrograma.Stop();
                //Interrompendo o cronômetro e registrando o tempo
                TimeSpan time = cronometroExecucaoPrograma.Elapsed;
                string hora = String.Format("{0:00}", time.Hours);
                string minuto = String.Format("{0:00}", time.Minutes);
                string segundo = String.Format("{0:00}", time.TotalSeconds);

                //Escrever no arquivo e no console as médias de resultados
                Escritor(resultadosShellSort1k, vetor1copy, vetor1, "\nALGORITMO SHELL SORT\n\n", escolherVetor, "1.000");
                Escritor(resultadosShellSort10k, vetor2copy, vetor2, "\n\nALGORITMO SHELL SORT\n\n", escolherVetor, "10.000");
                Escritor(resultadosShellSort100k, vetor3copy, vetor3, "\n\nALGORITMO SHELL SORT\n\n", escolherVetor, "100.000");
                Escritor(resultadosShellSort200k, vetor4copy, vetor4, "\n\nALGORITMO SHELL SORT\n\n", escolherVetor, "200.000");
                Escritor(resultadosMergeSort1k, vetor1copy, vetor1, "\nALGORITMO MERGE SORT\n\n", escolherVetor, "1.000");
                Escritor(resultadosMergeSort10k, vetor2copy, vetor2, "\nALGORITMO MERGE SORT\n\n", escolherVetor, "10.000");
                Escritor(resultadosMergeSort100k, vetor3copy, vetor3, "\nALGORITMO MERGE SORT\n\n", escolherVetor, "100.000");
                Escritor(resultadosMergeSort200k, vetor4copy, vetor4, "\nALGORITMO MERGE SORT\n\n", escolherVetor, "200.000");
                Escritor(resultadosQuickSort1k, vetor1copy, vetor1, "\nALGORITMO QUICK SORT\n\n", escolherVetor, "1.000");
                Escritor(resultadosQuickSort10k, vetor2copy, vetor2, "\nALGORITMO QUICK SORT\n\n", escolherVetor, "10.000");
                Escritor(resultadosQuickSort100k, vetor3copy, vetor3, "\nALGORITMO QUICK SORT\n\n", escolherVetor, "100.000");
                Escritor(resultadosQuickSort200k, vetor4copy, vetor4, "\nALGORITMO QUICK SORT\n\n", escolherVetor, "200.000");
                escritorArquivo.WriteLine($"\nTEMPO DE EXEUÇÃO DO PROGRAMA: {hora} Hora, {minuto} Minutos, {segundo} Segundos.");
                Console.WriteLine("PROGRAMA FINALIZDO!");
                escritorArquivo.Close();

                //Imprimindo vetores
                if (escolherVetor == 1)
                { ImprimirVetores(vetor1, vetor1copy);}
                if (escolherVetor == 2)
                {ImprimirVetores(vetor2, vetor2copy);}
                if (escolherVetor == 3)
                {ImprimirVetores(vetor3, vetor3copy); }
                if (escolherVetor == 4)
                { ImprimirVetores(vetor4, vetor4copy);}
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Você digitou um caractere inválido, o menu funciona apenas com números");
        }
    }
    //Algoritmo ShellSort
    static void VerificarDesempenhoShellSort(int[] vet, double[,] resultadosShellSort)
    {
        //Ordenando VETOR aleatório
        Stopwatch cronometroShellSort = new Stopwatch();
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        void InsercaoPorCor(int cor, int h)
        {
            for (int i = (h + cor); i < vet.Length; i += h)
            {
                int tmp = vet[i];
                int j = i - h;
                contadorComparacoesChaves++;
                while ((j >= 0) && (vet[j] > tmp))
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
                InsercaoPorCor(cor, h);
            }
        } while (h != 1);

        cronometroShellSort.Stop();
        TimeSpan time1 = cronometroShellSort.Elapsed;
        resultadosShellSort[0, 0] += contadorComparacoesChaves;
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
                InsercaoPorCor(cor, h);
            }
        } while (h != 1);
        cronometroShellSort.Stop();
        TimeSpan time2 = cronometroShellSort.Elapsed;
        resultadosShellSort[0, 1] += contadorComparacoesChaves;
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
                InsercaoPorCorInversamenteOrdenado(cor, h);
            }
        } while (h != 1);
        cronometroShellSort.Stop();
        TimeSpan time3 = cronometroShellSort.Elapsed;
        resultadosShellSort[0, 2] += contadorComparacoesChaves;
        resultadosShellSort[1, 2] += contadorMovimentacoesRegistros;
        resultadosShellSort[2, 2] += time3.Milliseconds;
        void InsercaoPorCorInversamenteOrdenado(int cor, int h)
        {
            for (int i = (h + cor); i < vet.Length; i += h)
            {
                int tmp = vet[i];
                int j = i - h;
                contadorComparacoesChaves++;
                while ((j >= 0) && (vet[j] < tmp))
                {
                    vet[j + h] = vet[j];
                    j -= h;
                    contadorMovimentacoesRegistros++;
                }
                vet[j + h] = tmp;
                contadorMovimentacoesRegistros++;
            }
        }

    }
    //Algoritmo MergeSort
    static void VerificarDesempenhoMergeSort(int[] vet, double[,] resultadosMergeSort)
    {
        int contadorComparacoesChaves = 0, contadorMovimentacoesRegistros = 0;
        int esq = 0, dir = vet.Length - 1;
        void Intercala(int[] vet, int esq, int meio, int dir)
        {
            int n1 = meio - esq + 1;
            int n2 = dir - meio;
            int[] vet_esq = new int[n1];
            int[] vet_dir = new int[n2];
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
                if (vet_esq[cont1] <= vet_dir[cont2])
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
        void IntercalaInversamente(int[] vet, int esq, int meio, int dir)
        {
            int n1 = meio - esq + 1;
            int n2 = dir - meio;
            int[] vet_esq = new int[n1];
            int[] vet_dir = new int[n2];
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
                if (vet_esq[cont1] >= vet_dir[cont2])
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
        void MergeSort1(int[] vet, int esq, int dir)
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
        void MergeSort2(int[] vet, int esq, int dir)
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
        void MergeSort3(int[] vet, int esq, int dir)
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
    //Algoritmo QuickSort
    static void VerificarDesempenhoQuickSort(int[] vet, double[,] resultadosQuickSort)
    {
        void Trocar(int i, int j)
        {
            int temp = vet[i];
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
        void Quicksort1(int[] vet, int esq, int dir)
        {
            int i = esq, j = dir, pivo = vet[(esq + dir) / 2];
            while (i <= j)
            {
                contadorComparacoesChaves++;
                while (vet[i] < pivo) { i++; }
                contadorComparacoesChaves++;
                while (vet[j] > pivo) { j--; }
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
        void Quicksort2(int[] vet, int esq, int dir)
        {
            int i = esq, j = dir, pivo = vet[(esq + dir) / 2];
            while (i <= j)
            {
                contadorComparacoesChaves++;
                while (vet[i] < pivo) { i++; }
                contadorComparacoesChaves++;
                while (vet[j] > pivo) { j--; }
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
        void Quicksort3(int[] vet, int esq, int dir)
        {
            cronometroQuickSort.Start();
            int i = esq, j = dir, pivo = vet[(esq + dir) / 2];
            while (i <= j)
            {
                contadorComparacoesChaves++;
                while (vet[i] > pivo) { i++; }
                contadorComparacoesChaves++;
                while (vet[j] < pivo) { j--; }
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
    //Escrevendo no arquivo as médias dos resultados
    static void Escritor(double[,] resultados, int[] vetcopy, int[] vet, string titulo, int escolherVetor, string tamanho)
    {
        //Escrevendo no arquivo
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