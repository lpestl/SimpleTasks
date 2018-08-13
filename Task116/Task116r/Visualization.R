nodes <- read.csv("Test3Nodes.csv", header = T, as.is = T);
links <- read.csv("Test3Edges.csv", header = T, as.is = T);

head(nodes)
head(links)
nrow(nodes); length(unique(nodes$id))
nrow(links); nrow(unique(links[,c("from", "to")]))

library(igraph)

net <- graph.data.frame(links, nodes, directed=T)
# Построить с изогнутыми ребрами (edge.curved=.1) и уменьшить размер стрелок:
plot(net, edge.arrow.size=.4, edge.curved=.1, edge.label=links$weight)
