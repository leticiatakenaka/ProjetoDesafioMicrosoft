using System;
using System.IO;

// O array ourAnimals armazenará as seguintes informações:
string animalEspecie = "";
string animalID = "";
string animalIdade = "";
string animalDescricaoFisica = "";
string animalDescricaoPersonalidade = "";
string animalApelido = "";

// Variáveis que suportam a entrada de dados
int maxPets = 8;
string? readResult;
string menuSelecao = "";
int petCount = 0;
string outroPet = "s";
bool entradaValida = false;
int idadePet = 0;

// Array usado para armazenar dados em tempo de execução, não há dados persistidos
string[,] ourAnimals = new string[maxPets, 6];

// Criar algumas entradas iniciais no array ourAnimals
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalEspecie = "cachorro";
            animalID = "d1";
            animalIdade = "2";
            animalDescricaoFisica = "cachorra retriever dourada de tamanho médio e cor creme, pesando cerca de 65 libras. Educada para fazer as necessidades no lugar certo.";
            animalDescricaoPersonalidade = "adora receber carinho na barriga e gosta de perseguir o próprio rabo. Dá muitos lambeijos.";
            animalApelido = "lola";
            break;

        case 1:
            animalEspecie = "cachorro";
            animalID = "d2";
            animalIdade = "9";
            animalDescricaoFisica = "cachorro retriever dourado grande de cor marrom-avermelhada, pesando cerca de 85 libras. Educado para fazer as necessidades no lugar certo.";
            animalDescricaoPersonalidade = "adora que coçem as orelhas quando ele te recebe na porta, ou a qualquer momento! Gosta de se inclinar e dar abraços caninos.";
            animalApelido = "loki";
            break;

        case 2:
            animalEspecie = "gato";
            animalID = "c3";
            animalIdade = "1";
            animalDescricaoFisica = "gata branca pequena pesando cerca de 8 libras. Educada para fazer as necessidades na caixa de areia.";
            animalDescricaoPersonalidade = "amigável";
            animalApelido = "Puss";
            break;

        case 3:
            animalEspecie = "gato";
            animalID = "c4";
            animalIdade = "?";
            animalDescricaoFisica = "";
            animalDescricaoPersonalidade = "";
            animalApelido = "";

            break;

        default:
            animalEspecie = "";
            animalID = "";
            animalIdade = "";
            animalDescricaoFisica = "";
            animalDescricaoPersonalidade = "";
            animalApelido = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Espécie: " + animalEspecie;
    ourAnimals[i, 2] = "Idade: " + animalIdade;
    ourAnimals[i, 3] = "Apelido: " + animalApelido;
    ourAnimals[i, 4] = "Descrição física: " + animalDescricaoFisica;
    ourAnimals[i, 5] = "Personalidade: " + animalDescricaoPersonalidade;
}

// Exibir as opções do menu de nível superior
do
{
    Console.Clear();

    Console.WriteLine("Bem-vindo ao aplicativo Contoso PetFriends. Suas opções de menu principal são:");
    Console.WriteLine(" 1. Listar todas as informações de nossos animais de estimação atuais");
    Console.WriteLine(" 2. Adicionar um novo amigo animal ao array ourAnimals");
    Console.WriteLine(" 3. Garantir que as idades e descrições físicas dos animais estejam completas");
    Console.WriteLine(" 4. Garantir que os apelidos e descrições de personalidade dos animais estejam completos");
    Console.WriteLine(" 5. Editar a idade de um animal");
    Console.WriteLine(" 6. Editar a descrição da personalidade de um animal");
    Console.WriteLine(" 7. Exibir todos os gatos com uma característica específica");
    Console.WriteLine(" 8. Exibir todos os cachorros com uma característica específica");
    Console.WriteLine();
    Console.WriteLine("Digite o número da sua seleção (ou digite Sair para sair do programa)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelecao = readResult.ToLower();
        // NOTA: Poderíamos colocar um bloco do-while em torno da entrada de menuSelecao para garantir uma entrada válida, mas usamos uma declaração condicional abaixo que processa apenas os valores de entrada válidos, então o bloco do-while não é necessário aqui.
    }

    // Usar switch-case para processar a opção de menu selecionada
    switch (menuSelecao)
    {
        case "1":
            // Listar todas as informações de nossos animais de estimação atuais
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j].ToString());
                    }
                }
            }
            Console.WriteLine("\nPressione a tecla Enter para continuar");
            readResult = Console.ReadLine();

            break;

        case "2":
            // Adicionar um novo amigo animal ao array ourAnimals
            //
            // O array ourAnimals contém
            //    1. a espécie (cachorro ou gato). um campo obrigatório
            //    2. o número de identificação - por exemplo C17
            //    3. a idade do animal. pode estar em branco na entrada inicial.
            //    4. o apelido do animal. pode estar em branco.
            //    5. uma descrição da aparência física do animal. pode estar em branco.
            //    6. uma descrição da personalidade do animal. pode estar em branco.

            outroPet = "s";
            petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"Atualmente temos {petCount} animais de estimação que precisam de um lar. Podemos gerenciar mais {(maxPets - petCount)}.");
            }

            while (outroPet == "s" && petCount < maxPets)
            {
                // Obter a espécie (cachorro ou gato) - string animalEspecie é um campo obrigatório 
                do
                {
                    Console.WriteLine("\nDigite 'cachorro' ou 'gato' para começar uma nova entrada");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalEspecie = readResult.ToLower();
                        if (animalEspecie != "cachorro" && animalEspecie != "gato")
                        {
                            //Console.WriteLine($"Você digitou: {animalEspecie}.");
                            entradaValida = false;
                        }
                        else
                        {
                            entradaValida = true;
                        }
                    }
                } while (entradaValida == false);

                // Construir o número de identificação do animal - por exemplo C1, C2, D3 (para Gato 1, Gato 2, Cachorro 3)
                animalID = animalEspecie.Substring(0, 1) + (petCount + 1).ToString();

                // Obter a idade do animal. pode ser ? na entrada inicial.
                do
                {
                    Console.WriteLine("Digite a idade do animal ou digite ? se desconhecida");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalIdade = readResult;
                        if (animalIdade != "?")
                        {
                            entradaValida = int.TryParse(animalIdade, out idadePet);
                        }
                        else
                        {
                            entradaValida = true;
                        }
                    }
                } while (entradaValida == false);


                // Obter uma descrição da aparência física do animal - animalDescricaoFisica pode estar em branco.
                do
                {
                    Console.WriteLine("Digite uma descrição física do animal (tamanho, cor, gênero, peso, educado para fazer as necessidades no lugar certo)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalDescricaoFisica = readResult.ToLower();
                        if (animalDescricaoFisica == "")
                        {
                            animalDescricaoFisica = "a ser determinado";
                        }
                    }
                } while (entradaValida == false);


                // Obter uma descrição da personalidade do animal - animalDescricaoPersonalidade pode estar em branco.
                do
                {
                    Console.WriteLine("Digite uma descrição da personalidade do animal (gosta ou não gosta, truques, nível de energia)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalDescricaoPersonalidade = readResult.ToLower();
                        if (animalDescricaoPersonalidade == "")
                        {
                            animalDescricaoPersonalidade = "a ser determinado";
                        }
                    }
                } while (entradaValida == false);


                // Obter o apelido do animal. animalApelido pode estar em branco.
                do
                {
                    Console.WriteLine("Digite um apelido para o animal");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalApelido = readResult.ToLower();
                        if (animalApelido == "")
                        {
                            animalApelido = "a ser determinado";
                        }
                    }
                } while (entradaValida == false);

                // Armazenar as informações do animal no array ourAnimals (base zero)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Espécie: " + animalEspecie;
                ourAnimals[petCount, 2] = "Idade: " + animalIdade;
                ourAnimals[petCount, 3] = "Apelido: " + animalApelido;
                ourAnimals[petCount, 4] = "Descrição física: " + animalDescricaoFisica;
                ourAnimals[petCount, 5] = "Personalidade: " + animalDescricaoPersonalidade;

                // incrementar petCount (o array é base zero, então incrementamos o contador após adicionar ao array)
                petCount = petCount + 1;

                // verificar limite maxPet
                if (petCount < maxPets)
                {
                    // outro animal?
                    Console.WriteLine("Deseja inserir informações para outro animal (s/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            outroPet = readResult.ToLower();
                        }

                    } while (outroPet != "s" && outroPet != "n");
                }
                //NOTA: O valor de outroPet (seja "s" ou "n") é avaliado na expressão da instrução while - no início do loop while
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("Alcançamos nosso limite no número de animais que podemos gerenciar.");
                Console.WriteLine("Pressione a tecla Enter para continuar.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // Garantir que as idades e descrições físicas dos animais estejam completas

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 1; j++)
                    {
                        bool idadeValida = true;

                        while (ourAnimals[i, 2] == "Idade: ?" || ourAnimals[i, 2] == "" || !idadeValida)
                        {
                            Console.WriteLine(ourAnimals[i, 0].ToString());

                            Console.WriteLine("Digite a idade do animal: ");
                            string entrada = Console.ReadLine();
                            int idade;
                            idadeValida = int.TryParse(entrada, out idade);
                            if (idadeValida)
                            {
                                ourAnimals[i, 2] = $"Idade: {idade}";
                            }
                        }

                        while (ourAnimals[i, 4] == "Descrição física: " || ourAnimals[i, 4] == "" || ourAnimals[i, 4] == null)
                        {
                            Console.WriteLine(ourAnimals[i, 0].ToString());

                            Console.WriteLine("Digite uma descrição física: ");
                            ourAnimals[i, 4] = $"Descrição física: {Console.ReadLine()}";
                        }

                    }
                }
            }

            Console.WriteLine("Os campos de idade e descrição física estão completos para todos os nossos amigos.");
            Console.WriteLine("Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Garantir que os apelidos e descrições de personalidade dos animais estejam completos

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 1; j++)
                    {
                        while (ourAnimals[i, 5] == "Personalidade: " || ourAnimals[i, 5] == "" || ourAnimals[i, 5] == null)
                        {
                            Console.WriteLine(ourAnimals[i, 0].ToString());

                            Console.WriteLine("Digite a personalidade: ");
                            ourAnimals[i, 5] = $"Personalidade: {Console.ReadLine()}";
                        }


                        while (ourAnimals[i, 3] == "Apelido: " || ourAnimals[i, 3] == "" || ourAnimals[i, 3] == null)
                        {
                            Console.WriteLine(ourAnimals[i, 0].ToString());

                            Console.WriteLine("Digite um apelido: ");
                            ourAnimals[i, 3] = $"Apelido: {Console.ReadLine()}";
                        }
                    }
                }
            }

            Console.WriteLine("Os campos de apelido e descrição de personalidade estão completos para todos os nossos amigos. \r\n");
            Console.WriteLine("Projeto de Desafio - por favor, volte em breve para ver o progresso.");
            Console.WriteLine("Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Editar a idade de um animal");
            Console.WriteLine("EM CONSTRUÇÃO - por favor, volte no próximo mês para ver o progresso.");
            Console.WriteLine("Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "6":
            // Editar a descrição da personalidade de um animal");
            Console.WriteLine("EM CONSTRUÇÃO - por favor, volte no próximo mês para ver o progresso.");
            Console.WriteLine("Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "7":
            // Exibir todos os gatos com uma característica específica
            Console.WriteLine("EM CONSTRUÇÃO - por favor, volte no próximo mês para ver o progresso.");
            Console.WriteLine("Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Exibir todos os cachorros com uma característica específica
            Console.WriteLine("EM CONSTRUÇÃO - por favor, volte no próximo mês para ver o progresso.");
            Console.WriteLine("Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelecao != "sair");
